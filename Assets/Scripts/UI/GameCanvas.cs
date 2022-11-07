using TMPro;
using UnityEngine;
using Zenject;

public class GameCanvas : MonoBehaviour
{
    [SerializeField] private Canvas _pauseCanvas;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _coins;

    private ScoreCouner _scoreCouner;

    [Inject]
    private void Construct(ScoreCouner scoreCouner)
    {
        _scoreCouner = scoreCouner;
    }

    private void Start()
    {
        _scoreCouner.ChangeScore += ChangeScore;
        //_squid.ChangeCountCoins += ChangeCoins;
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
        _scoreCouner.ChangeScore -= ChangeScore;
    }
}
