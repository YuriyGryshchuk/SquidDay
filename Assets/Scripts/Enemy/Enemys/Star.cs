using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : Enemy
{
    [SerializeField] private float _jumpHeight;

    private const float GRAVITY = 9.8f;

    private Vector3 _velocity;
    private Rigidbody2D _rigidbody2D;

    private void OnEnable()
    {
        _velocity = transform.up;
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Jump();
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(transform.up * _jumpHeight); 
    }

}
