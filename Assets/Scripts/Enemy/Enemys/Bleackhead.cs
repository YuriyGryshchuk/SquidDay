using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleackhead : Enemy
{
   private Vector3 _currentVector;
    private float _speed;

    private void OnEnable()
    {
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
        _speed = speed;
    }
}
