using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyChanger : MonoBehaviour
{
    public event Action<float> DifficultyChanged;

    private float _difficulty = 1;

    private void Start()
    {
        StartCoroutine(DifficultyCycle());
    }

    private IEnumerator DifficultyCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            _difficulty++;
            DifficultyChanged?.Invoke(_difficulty);
        }
    }
}
