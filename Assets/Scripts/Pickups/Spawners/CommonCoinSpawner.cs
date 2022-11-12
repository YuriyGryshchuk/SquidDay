using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonCoinSpawner : SpawnerBase<CommonCoin>
{
    [SerializeField]
    private PrearrangedSpawnPositionDispenser _spawnPositions;
    [SerializeField]
    private TimerSpawnSolver<CommonCoin> _timerSpawnSolver;

    protected override ISpawnPositionDispenser InitSpawnPositionDispeser()
    {
        return _spawnPositions;
    }

    protected override ISpawnSolver<CommonCoin> InitSpawnSolver()
    {
        return _timerSpawnSolver;
    }
}