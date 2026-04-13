using Assets.Scripts.Interface;
using System;
using UnityEngine;

public class ShipInfo : ScriptableObject, IUpgradble
{
    public event Action StatsChanged;

    public float BaseHealth { get; private set; }
    public float BaseAttack { get; private set; }
    public float BaseAttackSpeed { get; private set; }

    public int HealthLevel { get; private set; } = 1;
    public int AttackLevel { get; private set; } = 1;
    public int AttackSpeedLevel { get; private set; } = 1;

    private float _healthMultiplier = 0.05f;
    private float _attackMultiplier = 0.1f;
    private float _attackSpeedhMultiplier = 0.05f;

    public float Health()
    {
        return BaseHealth * (1 + _healthMultiplier * (HealthLevel - 1));
    }
    public float Attack()
    {
        return BaseAttack * (1 + _attackMultiplier * (AttackLevel - 1));
    }
    public float AttackSpeed()
    {
        return BaseAttackSpeed * (1 + _attackSpeedhMultiplier * (AttackSpeedLevel - 1));
    }

    public int GetHealthUpgradeCost()
    {
        return HealthLevel * 50;
    }
    public int GetAttackUpgradeCost()
    {
        return AttackLevel * 50;
    }
    public int GeAttackSpeedUpgradeCost()
    {
        return AttackSpeedLevel * 50;
    }

    public void UpgradeHealth()
    {
        HealthLevel++;
        StatsChanged?.Invoke();
    }
    public void UpgradeAttack()
    {
        AttackLevel++;
        StatsChanged?.Invoke();
    }
    public void UpgradeAttackSpeed()
    {
        AttackSpeedLevel++;
        StatsChanged?.Invoke();
    }
}