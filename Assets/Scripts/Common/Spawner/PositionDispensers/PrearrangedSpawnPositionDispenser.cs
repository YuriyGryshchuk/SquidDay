using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class PrearrangedSpawnPositionDispenser : ISpawnPositionDispenser
{
    [SerializeField] private Transform[] _spawnPositions;

    private int _previousSpawnPosition;
    private int _currentSpawnPosition;

    public Vector3 GetNextPosition()
    {
        CheckRepeatPosition();
         return new Vector3(_spawnPositions[_currentSpawnPosition].transform.position.x, 
             _spawnPositions[_currentSpawnPosition].transform.position.y, 0);
        // TODO implement unrepeated random points
    }

    private void CheckRepeatPosition()
    {
        _currentSpawnPosition = Random.Range(0, _spawnPositions.Length - 1);
        if (_currentSpawnPosition != _previousSpawnPosition)
        {
            _previousSpawnPosition = _currentSpawnPosition;
        }
    }
}
