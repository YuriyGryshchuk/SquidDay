using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidRotate : MonoBehaviour
{
    [SerializeField] private float _speedToRotate = 20;

    private void Update()
    {
        float rotation = Input.GetAxis("Horizontal") * _speedToRotate;
        rotation *= Time.deltaTime;
        transform.Rotate(0, 0, -rotation);
    }
}
