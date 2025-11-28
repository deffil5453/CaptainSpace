using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPopupManagerScript : MonoBehaviour
{
    [SerializeField] private ShipUpgradeManager _shipUpgradeManager;
    public void InfoShipWindow(Ship ship)
    {
        _shipUpgradeManager.ShowWindow(ship);
    }
}