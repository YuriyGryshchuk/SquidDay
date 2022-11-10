using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class Pickup : MonoBehaviour
{
    private DifficultyChanger _difficultyChanger;

    [Inject]
    private void Construct(DifficultyChanger difficultyChanger)
    {
        _difficultyChanger = difficultyChanger;
    }

    protected virtual void OnEnable()
    {
        if (_difficultyChanger != null)
            _difficultyChanger.DifficultyChanged += OnDifficultyChanged;
    }

    protected virtual void OnDisable()
    {
        _difficultyChanger.DifficultyChanged -= OnDifficultyChanged;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        if (playerHealth)
        {
            OnCollideWithPlayer(playerHealth);
        }
    }

    protected abstract void OnCollideWithPlayer(PlayerHealth playerHealth);
    protected virtual void OnDifficultyChanged(float difficulty) { }
}
