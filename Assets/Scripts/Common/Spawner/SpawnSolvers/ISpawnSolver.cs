public interface ISpawnSolver<T>
{
    public void Init(ISpawnMethod<T> spawner);
    public void Start();
    public void Stop();
}
