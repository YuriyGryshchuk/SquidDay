using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    [SerializeField] private float _time;

    [SerializeField] private Transform HeightSpawner;

    [SerializeField] private float _speedFall;

    private void Start()
    {
        StartCoroutine(Timer());
    }




    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(_time);
        Coin coin =  Instantiate(_coin, new Vector3(Random.Range(-12, 4), HeightSpawner.position.y, 1), Quaternion.identity);
        coin.Init(_speedFall);
        StartCoroutine(Timer());
    }
}
