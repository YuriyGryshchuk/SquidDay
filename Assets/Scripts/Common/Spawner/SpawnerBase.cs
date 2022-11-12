using UnityEngine;
using Zenject;

public abstract class SpawnerBase<TObject> : MonoBehaviour where TObject : Component
{
    [SerializeField] private float difficultyMultiplier = 0.03f;
    [SerializeField] private Factory<TObject> _factory;

    private DifficultyChanger _difficultyChanger;
    private ISpawnSolver<TObject> _spawnSolver;
    private ISpawnPositionDispenser _spawnPositionDispenser;
    private DiContainer _diContainer;
    protected float DifficultyMultiplier => difficultyMultiplier;

    [Inject]
    private void Construct(DifficultyChanger difficultyChanger, DiContainer diContainer)
    {
        _difficultyChanger = difficultyChanger;
        _diContainer = diContainer;
    }

    protected virtual void Start()
    {
        _difficultyChanger.DifficultyChanged += OnDifficultyChanged;
        _spawnPositionDispenser = InitSpawnPositionDispeser();
        _factory.Init(_spawnPositionDispenser, _diContainer);
        _factory.OnSpawn += OnObjectSpawned;
        _spawnSolver = InitSpawnSolver();
        _spawnSolver.Init(_factory);
        _spawnSolver.Start();
    }

    protected virtual void OnDestroy()
    {
        _spawnSolver.Stop();
    }

    protected abstract ISpawnPositionDispenser InitSpawnPositionDispeser();
    protected abstract ISpawnSolver<TObject> InitSpawnSolver();
    protected virtual void OnDifficultyChanged(float difficulty) { }
    protected virtual void OnObjectSpawned(TObject obj) { }
}