using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Squid : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _timeOfImmortality;
    [SerializeField] private RestartSystem _restartSystem;

    private int _score;
    private int _coins;
   
    private float _currentTimeImmortality;
    private float _currentTime;
    
    public event UnityAction<int, int> Die;
    public event UnityAction<int> ChangeHealth;
    public event UnityAction<int> ChangeScore;
    public event UnityAction<int> ChangeCountCoins;

    private void Start()
    {
        
        _currentTimeImmortality = 0;
        _currentTime = 0;
        _restartSystem.onRestart.AddListener(RestartStats);
        _restartSystem.onRevival.AddListener(Revival);
}

    private void Update()
    {
        _currentTime += Time.deltaTime;
        _currentTimeImmortality += Time.deltaTime;

        TakeScore();
      
    }

    public void PickCoin()
    {
       
        _coins += 1;
        ChangeCountCoins?.Invoke(_coins);
    }


    public int GetCoins()
    {
        return _coins;
    }

    public void RemoveCoins(int coins)
    {
        _coins -= coins;
    }
    public void TakeDamage()
    {
        if(_currentTimeImmortality >= _timeOfImmortality) { 

            
            _health -= 1;
            ChangeHealth?.Invoke(_health);

            _currentTimeImmortality = 0;

            if (_health == 0)
            {
                Dead();
            }
        }
    }

    public void QQPosition()
    {
     
        transform.position = -1 * (transform.position * 0.9f);
        _currentTimeImmortality = 0;
        
    }
    public void RestartStats()
    {
        this.gameObject.SetActive(true);
        transform.position = Vector3.zero;
        _health = 3;
        ChangeHealth?.Invoke(_health);
        _score = 0;
        ChangeScore?.Invoke(_score);
        
    }
    public void Revival()
    {
        this.gameObject.SetActive(true);
        _health = 3;
        ChangeHealth?.Invoke(_health);
        
    }

    private void Dead()
    {
        this.gameObject.SetActive(false);
        Die?.Invoke(_score, _coins);
    }

    private void TakeScore()
    {
        if(_currentTime >= 1)
        {
            _score++;
            ChangeScore?.Invoke(_score);
            _currentTime = 0;
        }

    }

    
}
