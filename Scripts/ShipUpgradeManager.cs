using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class ShipUpgradeManager : MonoBehaviour
{
    [Header("Информация о корабле")]
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _attackText;
    [SerializeField] private TMP_Text _attackSpeedText;

    [SerializeField] private Ship _ship;
    //private void Start()
    //{
    //    ScinInfoInizialize();
    //    Debug.Log(_ship);
    //    //_healthText = transform.Find("HealthBlock").Find("HealthText").GetComponent<TMP_Text>();
    //    //_attackText = transform.Find("AttackBlock").Find("AttackText").GetComponent<TMP_Text>();
    //    //_attackSpeedText = transform.Find("AttackSpeedBlock").Find("AttackSpeedText").GetComponent<TMP_Text>();
    //}
    private void ScinInfoInizialize()
    {
        _healthText.text = _ship.BaseHealth.ToString();
        _attackText.text = _ship.BaseAttack.ToString();

        if (YG2.envir.language == "ru")
        {
            _attackSpeedText.text = _ship.BaseAttackSpeed.ToString() + "/с";
        }
        else
        {
            _attackSpeedText.text = _ship.BaseAttackSpeed.ToString() + "/s";
        }
    }
    public void ShowWindow(Ship ship)
    {
        gameObject.SetActive(true);
        _ship = ship;
        ScinInfoInizialize();
    }
    public void CloseWindow()
    {
        gameObject.SetActive(false);
        //_ship = null;
    }
    public void BuyUpHealth()
    {
        if (MenuManager.TotalMoney < _ship.PriceUpHealth && _ship.CurrentHealthLevel < _ship.MaxLevel)
        {
            return;
        }
        _ship.BaseHealth += 20;
        _ship.CurrentHealthLevel++;
        EventsManager.UpActivation(-_ship.PriceUpHealth);
    }
    public void BuyUpAttack()
    {
        if (MenuManager.TotalMoney < _ship.PriceUpAttack && _ship.CurrentAttackLevel < _ship.MaxLevel)
        {
            return;
        }
        _ship.BaseAttack += 1;
        _ship.CurrentAttackLevel++;
        EventsManager.UpActivation(-_ship.PriceUpAttack);
    }
    public void BuyUpAttackSpeed()
    {
        if (MenuManager.TotalMoney < _ship.PriceUpAttackSpeed && _ship.CurrentAttackSpeedLevel < _ship.MaxLevel)
        {
            return;
        }
        _ship.BaseAttackSpeed += 1f;
        _ship.CurrentAttackSpeedLevel++;
        EventsManager.UpActivation(-_ship.PriceUpAttackSpeed);
    }
}
