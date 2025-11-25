using UnityEngine;
[CreateAssetMenu(fileName = "Inventory", menuName = "SpaceCaptain/Inventory", order = 98)]
public class Inventory : ScriptableObject
{
    public int Coins;
    public Ship CurrentShip;
}