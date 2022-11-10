using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class SpawnerBase<TObject> : MonoBehaviour where TObject : Component
{
    [SerializeField] protected TObject _spawnObject;
    [SerializeField] protected int _startPullSize = 10;
    [SerializeField] protected float _initialSpawnDelay;
    [SerializeField] protected float _difficultyMultiplier = 0.03f;

    protected List<TObject> _pullList = new List<TObject>();
    protected float _spawnDelay;
    protected float _currentTime;
    protected DifficultyChanger _difficultyChanger;
    protected ISpawnPositionDispenser _spawnPositionDispenser;

    private DiContainer _container;

    [Inject]
    private void Construct(DiContainer diContainer, DifficultyChanger difficultyChanger)
    {
        _container = diContainer;
        _difficultyChanger = difficultyChanger;
    }

    protected virtual void Start()
    {
        CreatePull();
        _spawnDelay = _initialSpawnDelay;
        _currentTime = 0f;
        _difficultyChanger.DifficultyChanged += OnDifficultyChanged;
        _spawnPositionDispenser = InitSpawnPositionDispeser();
    }

    protected virtual void Update()
    {
        SpawnDelay(_spawnDelay);
    }

    protected abstract ISpawnPositionDispenser InitSpawnPositionDispeser();
    protected virtual void OnDifficultyChanged(float difficulty) { }
    protected virtual void OnObjectSpawned(TObject obj) { }

    private void CreatePull()
    {
        for (int i = 0; i < _startPullSize; i++)
        {
            TObject obj = _container.InstantiatePrefabForComponent<TObject>(_spawnObject.gameObject);
            _pullList.Add(obj);
        }
        DisableAllObjects();
    }

    private void DisableAllObjects()
    {
        _currentTime = 0f;
        foreach (var obj in _pullList)
        {
            obj.gameObject.SetActive(false);
        }
    }

    protected void SpawnDelay(float timeWithSpawned)
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= timeWithSpawned)
        {
            Spawn();
            _currentTime = 0;
        }
    }

    private TObject SpawnAtPosition(Vector3 spawnPosition)
    {
        foreach (var obj in _pullList)
        {
            if (!obj.gameObject.activeSelf)
            {
                obj.gameObject.SetActive(true);
                obj.transform.position = spawnPosition;
                return obj;
            }
        }
        return null;
    }

    private void Spawn()
    {
        Vector3 newPosition = _spawnPositionDispenser.GetNextPosition();
        TObject obj = SpawnAtPosition(newPosition);
        if (obj != null)
        {
            OnObjectSpawned(obj);
        }
    }
}