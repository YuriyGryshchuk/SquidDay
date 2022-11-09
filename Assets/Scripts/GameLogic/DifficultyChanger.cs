using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyChanger : MonoBehaviour
{
    public event Action<float> DifficultyChanged;
    [SerializeField]
    private float _difficultyMultiplier = 1;
    private float _difficulty = 1;

    public float Difficulty => _difficulty;

    private void Start()
    {
        StartCoroutine(DifficultyCycle());
    }

    private IEnumerator DifficultyCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            _difficulty += _difficultyMultiplier;
            DifficultyChanged?.Invoke(_difficulty);
        }
    }
}
