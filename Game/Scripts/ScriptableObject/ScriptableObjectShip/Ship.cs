using EnumStateShip;
using UnityEngine;

[CreateAssetMenu(fileName = "Ship", menuName = "SpaceCaptain/Ship", order =99)]
public class Ship : ScriptableObject
{
    public string Key;
    public GameObject Prefab;

    public float BaseHealth;
    public float BaseAttack;
    public float BaseAttackSpeed;
        
    public int CurrentHealthLevel;
    public int CurrentAttackLevel;
    public int CurrentAttackSpeedLevel;
    //множители 
    [Header("насколько увеличивается каждый стат")]
    public float StepHealthUpgrade;
    public float StepAttackUpgrade;
    public float StepAttackSpeedUpgrade;
    //Стандартный шаг для увеличения цены
    public int MaxLevel = 30;
    [Header("цена корабля")]
    public int Price;
    public ShipState State;
    [Header("цена улучшений корабля")]
    public int PriceUpHealth;
    public int PriceUpAttack;
    public int PriceUpAttackSpeed;
    [Header("шаг для увеличения цены")]
    public int StepPriceMultiplier;

    [Header("Описание корабля")]
    public string ShipDescription;
    public string RuShipDescription;
}
