using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Squid>())
        {
            Squid squid = other.gameObject.GetComponent<Squid>();
            squid.TakeDamage();
        }
        
    }
}
