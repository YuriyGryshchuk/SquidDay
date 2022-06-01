using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadCanvas : MonoBehaviour
{
    [SerializeField] private Squid _squid;
    [SerializeField] private Canvas _deadCanvas;

    private void Start()
    {
        _squid.Die += Dead;
        _deadCanvas.enabled = false;
    }

    private void Dead(int score)
    {
        Time.timeScale = 0;
        _deadCanvas.enabled = true;
    }
}
