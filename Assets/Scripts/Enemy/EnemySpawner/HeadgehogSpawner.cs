using UnityEngine;
using Zenject;

public class HeadgehogSpawner : Spawner
{
    [SerializeField] private float _speed;
   
    private PlayerHealth _target;

    [Inject]
    private void Construct(PlayerHealth squid)
    {
        _target = squid;
    }

    protected override void InitEnemy(Enemy enemy)
    {
        base.InitEnemy(enemy);
        Headgehog ink = enemy.GetComponent<Headgehog>();
        ink.Init(_target, _speed);
    }
}

