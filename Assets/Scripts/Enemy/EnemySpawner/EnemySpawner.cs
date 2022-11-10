using UnityEngine;

public abstract class EnemySpawner<IObject> : SpawnerBase<IObject> where IObject : Enemy
{
    [SerializeField]
    private PrearrangedSpawnPositionDispenser _spawnPositions;

    protected override ISpawnPositionDispenser InitSpawnPositionDispeser()
    {
        return _spawnPositions;
    }

    protected override void OnObjectSpawned(IObject obj)
    {
        InitEnemy(obj);
    }

    protected override void OnDifficultyChanged(float difficulty)
    {
        _spawnDelay = _initialSpawnDelay / (difficulty * _difficultyMultiplier + 1);
    }

    protected abstract void InitEnemy(IObject enemy);
}
