using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : Enemy
{
    [SerializeField] private float _jumpHeight;
    private Rigidbody2D _rigidbody2D;

    private void OnEnable()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Jump();
    }

    private void Jump()
    {
        _rigidbody2D.AddForce(transform.up * _jumpHeight); 
    }

}
