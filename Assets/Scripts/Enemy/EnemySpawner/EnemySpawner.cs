using UnityEngine;

public abstract class EnemySpawner<IObject> : SpawnerBase<IObject> where IObject : Enemy
{
    [SerializeField]
    private PrearrangedSpawnPositionDispenser _spawnPositions;
    [SerializeField]
    private TimerSpawnSolver<IObject> _timerSpawnSolver;

    protected override ISpawnPositionDispenser InitSpawnPositionDispeser()
    {
        return _spawnPositions;
    }

    protected override ISpawnSolver<IObject> InitSpawnSolver()
    {
        return _timerSpawnSolver;
    }

    protected override void OnObjectSpawned(IObject obj)
    {
        InitEnemy(obj);
    }

    protected override void OnDifficultyChanged(float difficulty)
    {
        _timerSpawnSolver.SetSpawnDelay(_timerSpawnSolver.InitialSpawnDelay / (difficulty * DifficultyMultiplier + 1));
    }

    protected abstract void InitEnemy(IObject enemy);
}
