using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidRotate : MonoBehaviour
{
    [SerializeField] private float _speedToRotate = 20;

    private bool _isPressedLeft;
    private bool _isPressedRight;

    private void Update()
    {
        float rotation = Input.GetAxis("Horizontal") * _speedToRotate;
        rotation *= Time.deltaTime;
        transform.Rotate(0, 0, -rotation);

        if (_isPressedLeft)
            Rotate(-1);

        if (_isPressedRight)
            Rotate(1);
    }

    private void Rotate(float direction)
    {
        float rotation = direction * _speedToRotate;
        rotation *= Time.deltaTime;
        transform.Rotate(0, 0, -rotation);
    }

    public void OnDawnLeft()
    {
        _isPressedLeft = true;
    }

    public void OnUpLeft()
    {
        _isPressedLeft = false;
    }

    public void OnDawnRight()
    {
        _isPressedRight = true;
    }

    public void OnUpRight()
    {
        _isPressedRight = false;
    }
}
