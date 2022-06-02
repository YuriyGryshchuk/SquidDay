using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCanvas : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
}
