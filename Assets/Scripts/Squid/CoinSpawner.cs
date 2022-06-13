using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    [SerializeField] private float _time;

    [SerializeField] private Transform HeightSpawner;

    [SerializeField] private float _speedFall;


    [SerializeField] private RestartSystem _restartSystem;

    private List<Coin> _objectPull;

    private void Start()
    {
        
        CreateObjectPull();
        _restartSystem.onRestart.AddListener(DisableAllCoin);
        StartCoroutine(Timer());
    }




    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(_time);
        Coin coin = _objectPull[Random.Range(0, 7)];
        coin.gameObject.SetActive(true);
        coin.transform.position = new Vector3(Random.Range(-12, 4), HeightSpawner.position.y, 1);
       
        StartCoroutine(Timer());
    }

    private void CreateObjectPull()
    {
        _objectPull = new List<Coin>();
        for (int i = 0; i < 8; i++)
        {
            Coin coin = Instantiate(_coin, new Vector3(Random.Range(-12, 4), HeightSpawner.position.y, 1), Quaternion.identity);
            coin.Init(_speedFall);
            coin.gameObject.SetActive(false);
            _objectPull.Add(coin);
        }
       
    }
    private void DisableAllCoin()
    {
        foreach(Coin coin in _objectPull)
        {
            coin.gameObject.SetActive(false);
        }
    }
}
