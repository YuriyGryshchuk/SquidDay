using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private DifficultyChanger _difficultyChanger;

    private void Start()
    {
        // TODO: remove FindObjectOfType
        _difficultyChanger = FindObjectOfType<DifficultyChanger>();
        _difficultyChanger.DifficultyChanged += OnDifficultyChanged;
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
