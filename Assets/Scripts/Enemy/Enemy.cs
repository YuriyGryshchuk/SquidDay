using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected float EnemySpeed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        Squid squid = other.gameObject.GetComponent<Squid>();
        squid.TakeDamage();
    }
}
