using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackheadSpawner : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _timeWithSpawn;
    [SerializeField] private Transform[] _spawnPositions;
    [SerializeField] private int _startPullSize = 10;
    [SerializeField] private GameObject _enemy;

    private List<GameObject> _pullEnemy = new List<GameObject>();
    private float _currentTime;
    private int _previousSpawnPosition;
    private int _currentSpawnPosition;

    private void OnEnable()
    {
        CreatePullObject();
        _currentTime = 0f;
    }

    private void Update()
    {
        SpawnDelay(_timeWithSpawn);
    }

    private void CreatePullObject()
    {
        for (int i = 0; i <= _startPullSize; i++)
        {
            _pullEnemy.Add(Instantiate(_enemy, transform.position, Quaternion.identity));
        }

        foreach (var enemy in _pullEnemy)
        {
            enemy.SetActive(false);
        }
    }

    protected void SpawnEnemy()
    {
        foreach (var enemy in _pullEnemy)
        {
            if (!enemy.activeSelf)
            {
                enemy.SetActive(true);
                enemy.transform.position = new Vector3(_spawnPositions[_currentSpawnPosition].transform.position.x,
                    _spawnPositions[_currentSpawnPosition].transform.position.y, 0);
                Bleackhead ink = enemy.GetComponent<Bleackhead>();
                ink.Init(_speed);
                return;
            }
        }
    }

    protected void SpawnDelay(float timeWithSpawned)
    {
        _currentTime += Time.deltaTime;
        if (_currentTime >= timeWithSpawned)
        {
            _currentSpawnPosition = Random.Range(0, _spawnPositions.Length - 1);
            if (_currentSpawnPosition != _previousSpawnPosition)
            {
                _previousSpawnPosition = _currentSpawnPosition;
                SpawnEnemy();
                _currentTime = 0;
            }
        }
    }
}
