using EnumStateShip;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScinShipControl : MonoBehaviour
{
    [SerializeField] private Ship _ship;
    [SerializeField] private Inventory _inventory;
    //public int ScinNum;
    public int Price;
    //public int Id;

    public ShipState State;

    [SerializeField] private GameObject SpriteObject;

    public MenuManager MenuManagerScene;

    public TMP_Text PriceText;

    [SerializeField] private Button _buyButton;
    [SerializeField] private Button _selectedButton;
    public ShowPopupManagerScript _showPopupManagerScript;
    private void Start()
    {
        Price = _ship.Price;
        State = _ship.State;
        SpriteObject.GetComponent<SpriteRenderer>().sprite = _ship.Prefab.GetComponent<SpriteRenderer>().sprite;
        SpriteObject.GetComponent<Animator>().runtimeAnimatorController = _ship.Prefab.GetComponent<Animator>().runtimeAnimatorController;
        switch (State)
        {
            case ShipState.Buyed:
                Buy(false);
                break;
            case ShipState.Selected:
                Select();
                break;
        }
        if (PriceText != null)
        {
            PriceText.text = Price.ToString();
        }
        MenuManagerScene = FindObjectOfType<MenuManager>();
        _showPopupManagerScript = FindObjectOfType<ShowPopupManagerScript>();
    }
    //public Ship Ship
    //{
    //    get
    //    {
    //        return _ship;
    //    }
    //}
    public void ShowInfoShip()
    {
        _showPopupManagerScript.InfoShipWindow(_ship);
    }
    public void Buy(bool isBuy)
    {
        if (isBuy)
        {
            Debug.Log(MenuManager.TotalMoney);
            if (MenuManager.TotalMoney < Price)
            {
                return;
            }
            _buyButton.gameObject.SetActive(false);
            _selectedButton.gameObject.SetActive(true);
            _selectedButton.interactable = true;
            _selectedButton.gameObject.GetComponent<Animator>().enabled = true;
            _selectedButton.gameObject.GetComponentInChildren<TMP_Text>().text = "выбрать";
            _ship.State = ShipState.Buyed;
            MenuManager.TotalMoney -= Price;
            _inventory.Coins -= MenuManager.TotalMoney;
            PlayerPrefs.SetInt("PlayerMoney", MenuManager.TotalMoney);
            MenuManagerScene.UpdateMoneyText();
            PlayerPrefs.Save();
        }
        else
        {
            _buyButton.gameObject.SetActive(false);
            _selectedButton.gameObject.SetActive(true);
            _selectedButton.interactable = true;
            //_selectedButton.gameObject.GetComponent<Animator>().enabled = true;
            _selectedButton.gameObject.GetComponentInChildren<TMP_Text>().text = "выбрать";
            _ship.State = ShipState.Buyed;
        }

    }
    public void Select()
    {
        MenuManager.instance.ResetShip();
        _inventory.CurrentShip = _ship;
        State = ShipState.Selected;
        _ship.State = State;
        _buyButton.gameObject.SetActive(false);
        _selectedButton.gameObject.SetActive(true);
        _selectedButton.interactable = false;
        //_selectedButton.gameObject.GetComponent<Animator>().enabled = false;
        _selectedButton.gameObject.GetComponentInChildren<TMP_Text>().text = "выбран";
        Debug.Log(_selectedButton.gameObject.GetComponentInChildren<TMP_Text>().text);
    }
}