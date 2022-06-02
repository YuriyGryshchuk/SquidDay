using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseCanvas : MonoBehaviour
{
    [SerializeField] Canvas _pauseCanvas;

    private void Start()
    {
        _pauseCanvas.enabled = false;
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitToGame()
    {
        Time.timeScale = 1;
        _pauseCanvas.enabled = false;
    }
}
