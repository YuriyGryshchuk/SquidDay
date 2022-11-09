using UnityEngine;

public class BlackheadSpawner : EnemySpawner
{
    [SerializeField] private float _speed;
 
    protected override void InitEnemy(Enemy enemy)
    {
        Bleackhead bleackhead = enemy.GetComponent<Bleackhead>();
        bleackhead.Init(_speed);
    }
}
