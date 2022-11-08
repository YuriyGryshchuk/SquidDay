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
        Headgehog headgehog = enemy.GetComponent<Headgehog>();
        headgehog.Init(_target.gameObject, _speed);
    }
}

