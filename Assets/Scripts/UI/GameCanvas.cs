using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] private Canvas _pauseCanvas;
    [SerializeField] private Squid _squid;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _coins;

    private void Start()
    {
        _squid.ChangeScore += ChangeScore;
        _squid.ChangeCountCoins += ChangeCoins;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        _pauseCanvas.enabled = true;
    }

    private void ChangeScore(int score)
    {
        _score.text = score.ToString();
    }

    private void ChangeCoins(int coins)
    {
        _coins.text = coins.ToString();
    }

    private void OnDisable()
    {
        _squid.ChangeScore -= ChangeScore;
    }
}
