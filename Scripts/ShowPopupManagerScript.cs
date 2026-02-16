using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowPopupManagerScript : MonoBehaviour
{
    [SerializeField] private ShipUpgradeManager _shipUpgradeManager;
    public void InfoShipWindow(Ship ship)
    {
        SoundManager.Instance.PlaySound(SoundType.UIClick);
        _shipUpgradeManager.ShowWindow(ship);
    }
}