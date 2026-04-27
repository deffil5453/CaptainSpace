using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerPrefs = RedefineYG.PlayerPrefs;
public static class SaveShip
{
    private const string _HealthKey = "_HealthLevel";
    private const string _AttackKey = "_AttackLevel";
    private const string _AttackSpeedKey = "_AttackSpeedLevel";
    public static ShipModel LoadShipData(Ship ship)
    {
        ShipModel shipModel = new ShipModel(ship);
        string key = ship.name;

        shipModel.CurrentHealthLevel = PlayerPrefs.GetInt(key + _HealthKey, 0);
        shipModel.CurrentAttackLevel = PlayerPrefs.GetInt(key + _AttackKey, 0);
        shipModel.CurrentAttackSpeedLevel = PlayerPrefs.GetInt(key + _AttackSpeedKey, 0);
        //Debug.Log(shipModel.CurrentHealthLevel);
        return shipModel;
    }
    public static void SaveShipData(ShipModel shipModel)
    {
        string key = shipModel.Ship.name;
        PlayerPrefs.SetInt(key + _HealthKey, shipModel.CurrentHealthLevel);
        PlayerPrefs.SetInt(key + _AttackKey, shipModel.CurrentAttackLevel);
        PlayerPrefs.SetInt(key + _AttackSpeedKey, shipModel.CurrentAttackSpeedLevel);
        PlayerPrefs.Save();
    }
}