using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquitHeath : MonoBehaviour
{
    [SerializeField] private GameObject[] _healthImages;
    [SerializeField] private PlayerHealth _squid;

    private void Start()
    {
        _squid.ChangedHealth += ChangeHealth;
    }

    private void ChangeHealth(int HealthCell)
    {

       if(HealthCell == 3)
        {
            for (int i = 0; i < HealthCell; i++)
            {
               
                    _healthImages[i].SetActive(true);
                

            }
            return;
        }

        for (int i = 0; i <= HealthCell; i++)
        {
            if(i == HealthCell)
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
        _squid.ChangedHealth += ChangeHealth;
    }
}
