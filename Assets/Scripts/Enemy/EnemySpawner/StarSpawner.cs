
public class StarSpawner : Spawner
{
    protected override void InitEnemy(Enemy enemy)
    {
        Star start = enemy.GetComponent<Star>();
    }
}
