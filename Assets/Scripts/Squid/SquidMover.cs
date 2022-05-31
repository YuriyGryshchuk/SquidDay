using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidMover : MonoBehaviour
{
    [SerializeField] private float _pushForce = 3f;
    [SerializeField] private float _slowdown = 0.1f;
    [SerializeField] private float _timeToMove = 1f;

    private Vector2 _currentVector;
    private float _currentSpeed;
    private float _currentTime;

    private void Start()
    {
        _currentTime = 0;
    }

    private void Update()
    {
        Timer();
        PushSquid();
    }
    private void PushSquid()
    {
        if (_currentTime >= _timeToMove)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _currentVector = transform.up;
                _currentSpeed = _pushForce;
                _currentTime = 0;
            }
        }


        transform.Translate(_currentVector * _currentSpeed * Time.deltaTime, Space.World);
        _currentSpeed -= _slowdown;
        if (_currentSpeed <= 0)
            _currentSpeed = 0;
    }

    private void Timer()
    {
        _currentTime += Time.deltaTime;
    }
}
