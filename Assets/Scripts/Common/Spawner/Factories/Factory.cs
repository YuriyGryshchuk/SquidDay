using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[Serializable]
public class Factory<TObject> : ISpawnMethod<TObject> where TObject : Component
{
    [SerializeField] private TObject _spawnObject;
    [SerializeField] private int _startPullSize = 10;

    public event Action<TObject> OnSpawn;

    private List<TObject> _pullList = new List<TObject>();
    private ISpawnPositionDispenser _positionDispenser;
    private DiContainer _diContainer;

    public void Init(ISpawnPositionDispenser positionDispenser, DiContainer diContainer)
    {
        _diContainer = diContainer;
        _positionDispenser = positionDispenser;
        CreatePull();
    }

    private void CreatePull()
    {
        for (int i = 0; i < _startPullSize; i++)
        {
            TObject obj = _diContainer.InstantiatePrefabForComponent<TObject>(_spawnObject.gameObject);
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
        Vector3 newPosition = _positionDispenser.GetNextPosition();
        TObject obj = SpawnAtPosition(newPosition);
        if (obj != null)
        {
            OnSpawn?.Invoke(obj);
        }
    }
}