using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Vector3 _vectorDirection;

    private float _speed;

    private void Start()
    {
        _vectorDirection = new Vector3(0, -1, 0);
    }

   


    private void Update()
    {
        transform.Translate(_speed * Time.deltaTime * _vectorDirection);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Squid>())
        {


            other.GetComponent<Squid>().PickCoin();
            this.gameObject.SetActive(false);
        }
    }
    public void Init(float speed)
    {
        
        _speed = speed;

    }
}
