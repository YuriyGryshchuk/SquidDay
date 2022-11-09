using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleackhead : Enemy
{
    private Vector3 _currentVector;
    private float _initialSpeed;
    private float _speed;

    protected override void OnEnable()
    {
        base.OnEnable();
        _currentVector = new Vector3(-1, 0, 0);
    }

    private void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        transform.Translate(_currentVector * _speed * Time.deltaTime);
    }

    public void Init(float speed)
    {
        _initialSpeed = speed;
    }

    protected override void OnDifficultyChanged(float difficulty)
    {
        base.OnDifficultyChanged(difficulty);
        _speed = _initialSpeed + difficulty * 0.03f;
    }
}
