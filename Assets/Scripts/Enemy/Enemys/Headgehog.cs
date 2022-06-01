using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headgehog : Enemy
{
    [SerializeField] private GameObject _target;

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, EnemySpeed * Time.deltaTime);
    }
}
