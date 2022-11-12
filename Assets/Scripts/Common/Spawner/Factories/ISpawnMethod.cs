using System;
using Zenject;

public interface ISpawnMethod<TObject>
{
    public event Action<TObject> OnSpawn;

    void Init(ISpawnPositionDispenser positionDispenser, DiContainer diContainer);
    public void Spawn();
}
