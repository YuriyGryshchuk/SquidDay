using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] private Canvas _pauseCanvas;
    [SerializeField] private Squid _squid;
    [SerializeField] private TMP_Text _score;

    private void Start()
    {
        _squid.ChangeScore += ChangeScore;
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

    private void OnDisable()
    {
        _squid.ChangeScore -= ChangeScore;
    }
}
