using UnityEngine;

public class BlackheadSpawner : EnemySpawner<Bleackhead>
{
    [SerializeField] private float _speed;
 
    protected override void InitEnemy(Bleackhead enemy)
    {
        enemy.Init(_speed);
    }
}
