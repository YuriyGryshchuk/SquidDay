using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headgehog : Enemy
{
    private GameObject _target;
    private float _speed;

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
    }

    public void Init(GameObject target, float speed)
    {
        _target = target;
        _speed = speed;
    }
}
