using UnityEngine;
using Zenject;

public class PlayerHeathView : MonoBehaviour
{
    [SerializeField] private GameObject[] _healthImages;
    
    private PlayerHealth _playerHealth;

    [Inject]
    private void Conctruct(PlayerHealth playerHealth)
    {
        _playerHealth = playerHealth;
    }

    private void Start()
    {
        _playerHealth.ChangedHealth += ChangeHealth;
    }

    private void ChangeHealth(int healthCell)
    {

       if(healthCell == 3)
        {
            for (int i = 0; i < healthCell; i++)
            {
               
                    _healthImages[i].SetActive(true);
            }
            return;
        }

        for (int i = 0; i <= healthCell; i++)
        {
            if(i == healthCell)
            {
                _healthImages[i].SetActive(false);
            }
            else
            {
                _healthImages[i].SetActive(true);
            }
           
        }

    }

    private void OnDisable()
    {
        _playerHealth.ChangedHealth += ChangeHealth;
    }
}
