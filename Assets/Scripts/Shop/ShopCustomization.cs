using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCustomization : MonoBehaviour
{
    [SerializeField] private List<Item> _hats; 
    [SerializeField] private List<Item> _decoratings;
    [SerializeField] private Squid _squid;
    private SquidCustomization _squidCustomization;
    [SerializeField] private List<Item> _purchasedItems;

    private void Start()
    {
        
        
        _squidCustomization = _squid.GetComponent<SquidCustomization>();
    }
    public void SetHat(int indexHat)
    {

    }

    public void SetDecorating(int indexDecorating)
    {

    }


    public List<Item> GetHats()
    {
        return _hats;

    }

    public List<Item> GetDecoratings()
    {
        return _decoratings;
    }
    public void Buy(Item hat, Item decorating, int cost)
    {

        EquipHat(hat);
        EquipDecorating(decorating);
        _purchasedItems.Add(hat);
        _purchasedItems.Add(decorating);
        _squid.RemoveCoins(cost);
    }
    public void EquipHat(Item hat)
    {
        _squidCustomization.EquipHat(hat);
    }
    public void EquipDecorating(Item decorating)
    {
        _squidCustomization.EquipDecorating(decorating);
    }
    public int GetCoinsSquid()
    {
        return _squid.GetCoins();
    }
    public bool isPurschased(Item item)
    {
       

        return _purchasedItems.Contains(item);
    }
}
