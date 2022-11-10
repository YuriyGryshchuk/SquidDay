using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class SpawnerBase<TObject> : MonoBehaviour, ISpawnMethod where TObject : Component
{
    [SerializeField] protected TObject _spawnObject;
    [SerializeField] protected int _startPullSize = 10;
    [SerializeField] protected float _difficultyMultiplier = 0.03f;

    protected List<TObject> _pullList = new List<TObject>();
    protected DifficultyChanger _difficultyChanger;
    protected ISpawnPositionDispenser _spawnPositionDispenser;
    protected ISpawnSolver _spawnSolver;

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
        _difficultyChanger.DifficultyChanged += OnDifficultyChanged;
        _spawnPositionDispenser = InitSpawnPositionDispeser();
        _spawnSolver = InitSpawnSolver();
        _spawnSolver.Init(this);
        _spawnSolver.Start();
    }

    protected virtual void OnDestroy()
    {
        _spawnSolver.Stop();
    }

    protected abstract ISpawnPositionDispenser InitSpawnPositionDispeser();
    protected abstract ISpawnSolver InitSpawnSolver();
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
        foreach (var obj in _pullList)
        {
            obj.gameObject.SetActive(false);
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

    public void Spawn()
    {
        Vector3 newPosition = _spawnPositionDispenser.GetNextPosition();
        TObject obj = SpawnAtPosition(newPosition);
        if (obj != null)
        {
            OnObjectSpawned(obj);
        }
    }
}