using UnityEngine;

public class PlayerDestroer : MonoBehaviour
{
    [SerializeField] private PlayerDestroer OppositeDestroyer;

    public bool isActive = true;
     

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerHealth>() && isActive)
        {
            PlayerHealth squid = other.gameObject.GetComponent<PlayerHealth>();
            
            //squid.QQPosition();

            OppositeDestroyer.isActive = false;

        }
        
    }
 
    private void OnTriggerExit2D(Collider2D other)
    {
        isActive = true;
    }

    
}
