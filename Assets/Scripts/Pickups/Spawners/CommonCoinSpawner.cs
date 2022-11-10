using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonCoinSpawner : PickupSpawner<CommonCoin>
{
    [SerializeField]
    private PrearrangedSpawnPositionDispenser _spawnPositions;
    [SerializeField]
    private TimerSpawnSolver _timerSpawnSolver;

    protected override ISpawnPositionDispenser InitSpawnPositionDispeser()
    {
        return _spawnPositions;
    }

    protected override ISpawnSolver InitSpawnSolver()
    {
        return _timerSpawnSolver;
    }

    protected override void OnObjectSpawned(CommonCoin obj)
    {

    }
}
