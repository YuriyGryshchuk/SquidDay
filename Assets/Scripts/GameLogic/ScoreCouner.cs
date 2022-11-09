using System;
using System.Collections;
using UnityEngine;

public class ScoreCouner : MonoBehaviour
{
    [SerializeField]
    private int _scorePerSecond = 1;

    private int _score;

    public event Action<int> ChangeScore;

    private void Start()
    {
        StartCoroutine(ScoreCount());
    }

    private IEnumerator ScoreCount()
    {
        while(Time.timeScale == 1)
        {
            _score += _scorePerSecond;
            yield return new WaitForSeconds(1);
            ChangeScore?.Invoke(_score);
        }
    }
}
