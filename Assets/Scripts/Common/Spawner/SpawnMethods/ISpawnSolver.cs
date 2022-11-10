using System;
using UnityEngine;

public interface ISpawnSolver
{
    public void Init(ISpawnMethod spawner);
    public void Start();
    public void Stop();
}
