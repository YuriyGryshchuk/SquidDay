using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Item : ScriptableObject
{

    [SerializeField] private string _name;

    [SerializeField] private int _cost;

    [SerializeField] private Sprite _sprite;

    
    
    public string GetName()
    {
        return _name;
    }

    public int GetCost()
    {
        return _cost;
    }

    public Sprite GetSprite()
    {
        return _sprite;
    }


    
}
