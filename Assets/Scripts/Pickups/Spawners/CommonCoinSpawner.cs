using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonCoinSpawner : PickupSpawner<CommonCoin>
{
    [SerializeField]
    private PrearrangedSpawnPositionDispenser _spawnPositions;

    protected override ISpawnPositionDispenser InitSpawnPositionDispeser()
    {
        return _spawnPositions;
    }

    protected override void OnObjectSpawned(CommonCoin obj)
    {

    }
}
