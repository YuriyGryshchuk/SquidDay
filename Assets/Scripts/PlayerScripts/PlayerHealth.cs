using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _timeOfImmortality;

    private int _coins;

    private float _currentTimeImmortality;

    public event Action Dead;
    public event Action<int> ChangedHealth;
    //public event UnityAction<int> ChangeCountCoins;

    private void Start()
    {
        _currentTimeImmortality = 0;
    }

    private void Update()
    {
        _currentTimeImmortality += Time.deltaTime;
    }

    public void TakeDamage()
    {
        if (_currentTimeImmortality >= _timeOfImmortality)
        {
            _health -= 1;
            ChangedHealth?.Invoke(_health);
            if (_health == 0)
            {
                Die();
            }
            _currentTimeImmortality = 0;
        }
    }

    private void Die()
    {
        Time.timeScale = 0;
        Dead?.Invoke();
    }
}
