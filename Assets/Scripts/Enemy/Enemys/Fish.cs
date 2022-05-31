using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : Enemy
{
    [SerializeField] private float _speedToRotate = 5f;
    [SerializeField] private GameObject _target;

    private Vector3 _directionToTarget;

    private void Update()
    {
        RotateToTarget();
        MoveToTarget();
    }

    private void RotateToTarget()
    {
        
    }

    private void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, EnemySpeed * Time.deltaTime);
    }
}
