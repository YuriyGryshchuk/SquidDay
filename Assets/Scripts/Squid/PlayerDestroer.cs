using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroer : MonoBehaviour
{
    [SerializeField] private PlayerDestroer OppositeDestroyer;

    public bool isActive = true;
     

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Squid>() && isActive)
        {
            Squid squid = other.gameObject.GetComponent<Squid>();
            
            squid.RestartPosition();

            OppositeDestroyer.isActive = false;

        }
        
    }
 
    private void OnTriggerExit2D(Collider2D other)
    {
        isActive = true;
    }

    
}
