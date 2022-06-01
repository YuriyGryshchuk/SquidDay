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
    private float _currentTime;

    public event UnityAction<int> Die;

    private void Start()
    {
        _startPosition = transform.position;
        _currentTime = 0;
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
    }

    public void TakeDamage()
    {
        if(_currentTime >= _timeOfImmortality)
        {
            _health -= 1;
            transform.position = _startPosition;
            _currentTime = 0;

            if (_health == 0)
            {
                Dead();
            }
        }
    }

    private void Dead()
    {
        Die?.Invoke(_score);
    }
}
