using EnumStateShip;
using UnityEngine;

[CreateAssetMenu(fileName = "Ship", menuName = "SpaceCaptain/Ship", order =99)]
public class Ship : ScriptableObject
{
    public GameObject Prefab;

    public float BaseHealth;
    public float BaseAttack;
    public float BaseAttackSpeed;
    public int CurrentHealthLevel;
    public int CurrentAttackLevel;
    public int CurrentAttackSpeedLevel;
    public int MaxLevel;

    public int Price;
    public ShipState State;

    public int PriceUpHealth;
    public int PriceUpAttack;
    public int PriceUpAttackSpeed;
}
