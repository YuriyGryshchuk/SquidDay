using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class TimerSpawnSolver : ISpawnSolver
{
    [SerializeField]
    private float _spawnDelayInSeconds;

    private ISpawnMethod _spawner;
    private int _spawnDelay;
    private Task _cycle;
    private bool isWorking = false;

    public float SpawnDelayInSeconds => _spawnDelayInSeconds;
    public void SetSpawnDelay(float second)
    {
        _spawnDelay = (int)(second * 1000);
    }

    public void Init(ISpawnMethod spawner)
    {
        _spawner = spawner;
        _spawnDelay = (int)(_spawnDelayInSeconds * 1000);
    }

    public void Start()
    {
        isWorking = true;
        _cycle = TimerCycle();
    }

    public void Stop()
    {
        isWorking = false;
    }

    private async Task TimerCycle()
    {
        while (true)
        {
            await Task.Delay(_spawnDelay);
            if (!isWorking)
                break;
            _spawner.Spawn();
        }
    }
}
