using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headgehog : Enemy
{
    private GameObject _target;
    private float _speed;
    [SerializeField]
    private float _rotationSpeed = 5;

    private void Update()
    {
        MoveToTarget();
        RotateToTarget();
    }

    private void MoveToTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
    }

    private void RotateToTarget()
    {
        Vector3 vectorToTarget = _target.transform.position - transform.position;
        float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * _rotationSpeed);
    }

    public void Init(GameObject target, float speed)
    {
        _target = target;
        _speed = speed;
    }
}
