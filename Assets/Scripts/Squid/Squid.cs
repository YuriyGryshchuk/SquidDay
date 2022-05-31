using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squid : MonoBehaviour
{
    [SerializeField] private int _health;

    private int _score;
    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    public void TakeDamage()
    {
        _health -= 1;
        transform.position = _startPosition;

        //if (_health = 0)
        //{
        //    Dead()
        //}
    }
}
