using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ShopCanvas : MonoBehaviour
{

    [SerializeField] private ShopCustomization _shop;

    [SerializeField] [Tooltip("0 - left button, 1 - right button")] private List<Button> _buttonHats;

    [SerializeField] [Tooltip("0 - left button, 1 - right button")] private List<Button> _buttonDecoratings;

    [SerializeField] private Button Interactable;


    [SerializeField] private TMP_Text _costText;

    [SerializeField] private string Equip;
    [SerializeField] private string Purschase;

    [SerializeField] private List<Image> HatCells;
    [SerializeField] private List<Image> DecoratingCells;

    private List<Item> _hats;
    private List<Item> _decoratings;

    private int _cost;
    private Item _currentHat;
    private Item _currentDecorating;

    private void Start()
    {
        _hats = new List<Item>();
        _decoratings = new List<Item>();

        InitShop();
        _currentHat = _hats[0];
        _currentDecorating = _decoratings[0];

        InitItems(_hats, HatCells, _currentHat);
        InitItems(_decoratings, DecoratingCells, _currentDecorating);
        Recalculation();
        Disable();
    }



    private void InitShop()
    {
        _hats.AddRange(_shop.GetHats());
        _decoratings.AddRange(_shop.GetDecoratings());

    }

    private void InitItems(List<Item> items, List<Image> cells, Item currentItem)
    {
        for (int i = 0; i < cells.Count; i++)
        {
           

            int index = (i + items.IndexOf(currentItem)) - 1;


            if (index - cells.Count >= 0)
            {
                index = index - (items.Count);
            }
            if (index < 0)
            {
                index = index + items.Count;
            }

            cells[i].gameObject.SetActive(true);
            cells[i].sprite = items[index].GetSprite();
            if (items[index].GetSprite() == null)
            {
                cells[i].gameObject.SetActive(false);
            }

        }

    }

    public void SwitchDecorating(int index)
    {
       
            if (_decoratings.IndexOf(_currentDecorating) == _decoratings.Count - 1)
            {
                _currentDecorating = _decoratings[0];

            }
            else if (_decoratings.IndexOf(_currentDecorating) + index < 0)
            {
                _currentDecorating = _decoratings[_decoratings.Count - 1];

            }
            else
            {
                _currentDecorating = _decoratings[_decoratings.IndexOf(_currentDecorating) + index];
            }
        
      


        InitItems(_decoratings, DecoratingCells, _currentDecorating);
        Recalculation();
    
    }
    public void SwitchHat(int index)
    {
        
        
            if (_hats.IndexOf(_currentHat) == _hats.Count - 1)
            {
                _currentHat = _hats[0];

            }
            else if (_hats.IndexOf(_currentHat) + index < 0)
            {
                _currentHat = _hats[_hats.Count - 1];

            }
            else
            {
                _currentHat = _hats[_hats.IndexOf(_currentHat) + index];
            }
        

        InitItems(_hats, HatCells, _currentHat);
        Recalculation();
        
    }


    private void Recalculation()
    {
        _cost = _currentDecorating.GetCost() + _currentHat.GetCost();
        _costText.text = _cost.ToString();
        if (_shop.GetCoinsSquid() < _cost)
        {
            _costText.color = Color.red;
            Interactable.interactable = false;
            

        }
        if (_shop.isPurschased(_currentHat) && _shop.isPurschased(_currentDecorating))
        {
            Interactable.gameObject.SetActive(false);
            _costText.gameObject.SetActive(false);
            
        }
       
        else
        {
            if (_shop.isPurschased(_currentHat))
            {
                _shop.EquipHat(_currentHat);

                _cost -= _currentHat.GetCost();


            }
            if (_shop.isPurschased(_currentDecorating))
            {
                _shop.EquipDecorating(_currentDecorating);

                _cost -= _currentDecorating.GetCost();

            }
            _costText.gameObject.SetActive(true);
            _costText.color = Color.white;
            Interactable.gameObject.SetActive(true);
            Interactable.interactable = true;
        }
      
        

    }
    public void Buy()
    {
        _shop.Buy(_currentHat, _currentDecorating, _cost);
    }
    public void Enable()
    {
        this.gameObject.SetActive(true);
    }
    public void Disable()
    {
        this.gameObject.SetActive(false);
    }
}
