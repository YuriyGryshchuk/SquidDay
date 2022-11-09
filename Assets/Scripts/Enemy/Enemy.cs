using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private DifficultyChanger _difficultyChanger;

    public void SetDifficultyChanger(DifficultyChanger difficultyChanger)
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
        if (other.GetComponent<PlayerHealth>())
        {
            PlayerHealth squid = other.gameObject.GetComponent<PlayerHealth>();
            squid.TakeDamage();
        }
    }

    protected virtual void OnDifficultyChanged(float difficulty)
    {

    }
}
