using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonCoin : Pickup
{
    protected override void OnCollideWithPlayer(PlayerHealth playerHealth)
    {
        gameObject.SetActive(false);
    }

    protected override void OnDifficultyChanged(float difficulty) 
    {

    }
}
