using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Squid : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _timeOfImmortality;

    private int _score;
    private Vector3 _startPosition;
    private float _currentTimeImmortality;
    private float _currentTime;

    public event UnityAction<int> Die;
    public event UnityAction<int> ChangeHealth;
    public event UnityAction<int> ChangeScore;

    private void Start()
    {
        _startPosition = transform.position;
        _currentTimeImmortality = 0;
        _currentTime = 0;
}

    private void Update()
    {
        _currentTime += Time.deltaTime;
        _currentTimeImmortality += Time.deltaTime;

        TakeScore();
    }

    public void TakeDamage()
    {
        if(_currentTimeImmortality >= _timeOfImmortality)
        {
            _health -= 1;
            ChangeHealth?.Invoke(_health);
            transform.position = _startPosition;
            _currentTimeImmortality = 0;

            if (_health == 0)
            {
                Dead();
            }
        }
    }

    public void RestartPosition()
    {
        transform.position = _startPosition;
        _currentTimeImmortality = 0;
    }

    private void Dead()
    {
        Die?.Invoke(_score);
    }

    private void TakeScore()
    {
        if(_currentTime >= 1)
        {
            _score++;
            ChangeScore?.Invoke(_score);
            _currentTime = 0;
        }

    }
}
