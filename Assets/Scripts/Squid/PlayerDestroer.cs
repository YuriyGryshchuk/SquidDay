using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Squid squid = other.gameObject.GetComponent<Squid>();
        squid.RestartPosition();
    }
}
