using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

[Serializable]
public class TimerSpawnSolver<T> : ISpawnSolver<T>
{
    [SerializeField]
    private float _initialSpawnDelay = 1f;

    private ISpawnMethod<T> _spawner;
    private float _currentSpawnDelay;
    private Task _cycle;
    private CancellationTokenSource _cancellationToken;
    private bool isWorking = false;

    public float InitialSpawnDelay => _initialSpawnDelay;
    public bool IsWorking => isWorking;

    public void SetSpawnDelay(float second)
    {
        _currentSpawnDelay = second;
    }

    public void Init(ISpawnMethod<T> spawner)
    {
        _spawner = spawner;
        _currentSpawnDelay = _initialSpawnDelay;
    }

    public void Start()
    {
        if (isWorking == true)
        {
            Stop();
        }
        isWorking = true;
        _cancellationToken = new CancellationTokenSource();
        _cycle = TimerCycle(_cancellationToken.Token);
    }

    public void Stop()
    {
        isWorking = false;
        _cancellationToken?.Cancel();
        _cycle = null;
    }

    private void Restart()
    {

    }

    private async Task TimerCycle(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            await Delay(_currentSpawnDelay, token);
            _spawner.Spawn();
        }
    }

    private async Task Delay(float seconds, CancellationToken token)
    {
        float elapsed = 0f;
        do
        {
            token.ThrowIfCancellationRequested();
            await Task.Yield();
            elapsed += Time.deltaTime;
        } while (elapsed < seconds);
    }
}
