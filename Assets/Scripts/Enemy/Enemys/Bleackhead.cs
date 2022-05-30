using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bleackhead : Enemy
{
   private Vector3 _currentVector;

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
        transform.Translate(_currentVector * EnemySpeed * Time.deltaTime);
    }
}
