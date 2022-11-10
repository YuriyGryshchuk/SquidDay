using UnityEngine;
using Zenject;

public class HeadgehogSpawner : EnemySpawner<Hedgehog>
{
    [SerializeField] private float _speed;
   
    private PlayerHealth _target;

    [Inject]
    private void Construct(PlayerHealth squid)
    {
        _target = squid;
    }

    protected override void InitEnemy(Hedgehog enemy)
    {
        enemy.Init(_target.gameObject, _speed);
    }
}

