using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DeadCanvas : MonoBehaviour
{
    [SerializeField] private Squid _squid;
    [SerializeField] private Canvas _deadCanvas;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private TMP_Text _coins;
   

    private void Start()
    {
        _squid.Die += Dead;
        _deadCanvas.enabled = false;
    }

    private void Dead(int score, int coins)
    {

        Time.timeScale = 0;
        _deadCanvas.enabled = true;
        _score.text = score.ToString();
        _coins.text = coins.ToString();
        Debug.Log(_coins.text);
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
