using UnityEngine;
using Zenject;

public class HeadgehogSpawner : EnemySpawner
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
        Hedgehog headgehog = enemy.GetComponent<Hedgehog>();
        headgehog.Init(_target.gameObject, _speed);
    }
}

