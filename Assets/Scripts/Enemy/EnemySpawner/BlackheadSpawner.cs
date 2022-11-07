using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackheadSpawner : Spawner
{
    [SerializeField] private float _speed;
 
    protected override void InitEnemy(Enemy enemy)
    {
        Bleackhead ink = enemy.GetComponent<Bleackhead>();
        ink.Init(_speed);
    }
}
