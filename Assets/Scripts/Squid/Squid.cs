using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Squid : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private float _timeOfImmortality;

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
}

    private void Update()
    {
        _currentTime += Time.deltaTime;
        _currentTimeImmortality += Time.deltaTime;

        TakeScore();
    }



    public void GetCoin()
    {
        _coins += 1;
        ChangeCountCoins?.Invoke(_coins);
    }


    public void TakeDamage()
    {
        if(_currentTimeImmortality >= _timeOfImmortality) { 

            ChangeHealth?.Invoke(_health);
            _health -= 1;
            
           
            _currentTimeImmortality = 0;

            if (_health == 0)
            {
                Dead();
            }
        }
    }

    public void RestartPosition()
    {
     
        transform.position = -1 * (transform.position * 0.9f);
        _currentTimeImmortality = 0;
        
    }

    private void Dead()
    {
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
