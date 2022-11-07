using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerHealth>())
        {
            PlayerHealth squid = other.gameObject.GetComponent<PlayerHealth>();
            squid.TakeDamage();
        }
        
    }
}
