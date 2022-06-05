using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquitHeath : MonoBehaviour
{
    [SerializeField] private GameObject[] _healthImages;
    [SerializeField] private Squid _squid;

    private void Start()
    {
        _squid.ChangeHealth += ChangeHealth;
    }

    private void ChangeHealth(int HealthCell)
    {
        if (HealthCell > _healthImages.Length)
            HealthCell = _healthImages.Length;

        //foreach (var image in _healthImages)
        //{
        //    image.SetActive(false);
        //}

        //for (int i = 0; i <= health - 1; i++)
        //{
        //    _healthImages[i].SetActive(true);
        //}
        _healthImages[HealthCell - 1].SetActive(false);
    }

    private void OnDisable()
    {
        _squid.ChangeHealth += ChangeHealth;
    }
}
