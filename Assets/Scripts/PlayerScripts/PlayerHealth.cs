using System;
using UnityEngine;
using Zenject;

public class PlayerHealth : MonoBehaviour
{
    private int _coins;
    private float _currentTimeImmortality;
    private  PlayerConfig _playerConfig;
    private int _health;

    public event Action Dead;
    public event Action<int> ChangedHealth;
    //public event UnityAction<int> ChangeCountCoins;

    [Inject]
    private void Conctruct(PlayerConfig playerConfig)
    {
        _playerConfig = playerConfig;
    }

    private void Start()
    {
        _currentTimeImmortality = 0;
        _health = _playerConfig.PlayerHealth;
    }

    private void Update()
    {
        _currentTimeImmortality += Time.deltaTime;
    }

    public void TakeDamage()
    {
        if (_currentTimeImmortality >= _playerConfig.TimeOfImmortalityOnDamage)
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
