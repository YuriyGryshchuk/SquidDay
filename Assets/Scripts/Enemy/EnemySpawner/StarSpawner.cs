
public class StarSpawner : EnemySpawner
{
    protected override void InitEnemy(Enemy enemy)
    {
        Star start = enemy.GetComponent<Star>();
    }
}
