using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadgehogSpawner : Spawner
{
    [SerializeField] private GameObject _target;
    [SerializeField] private float _speed;
   
    protected override void InitEnemy(Enemy enemy)
    {
        base.InitEnemy(enemy);
        Headgehog ink = enemy.GetComponent<Headgehog>();
        ink.Init(_target, _speed);
    }
}

