using UnityEngine;

[System.Serializable]
public class ShipModel
{
    [SerializeField] private Ship _ship;


    [SerializeField] private int _currentHealthLevel;
    [SerializeField] private int _currentAttackLevel;
    [SerializeField] private int _currentAttackSpeedLevel;
    public Ship Ship => _ship;
    public float CurrentHealth => _ship.BaseHealth + (_currentHealthLevel * _ship.StepHealthUpgrade);
    public float CurrentAttack => _ship.BaseAttack + (_currentAttackLevel * _ship.StepAttackUpgrade);
    public float CurrentAttackSpeed => _ship.BaseAttackSpeed + (_currentAttackSpeedLevel * _ship.StepAttackSpeedUpgrade);
    public float MaxHealth => _ship.BaseHealth + (_ship.MaxLevel * _ship.StepHealthUpgrade);
    public float MaxAttack => _ship.BaseAttack + (_ship.MaxLevel * _ship.StepAttackUpgrade);
    public float MaxAttackSpeed => _ship.BaseAttackSpeed + (_ship.MaxLevel * _ship.StepAttackSpeedUpgrade);
    public int CurrentHealthLevel
    {
        get
        {
            return _currentHealthLevel;
        }
        set
        {
            _currentHealthLevel = value;
        }
    }
    public int CurrentAttackLevel 
    {
        get { return _currentAttackLevel; }
        set { _currentAttackLevel = value; }
    }
    public int CurrentAttackSpeedLevel
    {
        get { return _currentAttackSpeedLevel; }
        set { _currentAttackSpeedLevel = value; }
    }
    public float HealthFillAmount => CurrentHealth / MaxHealth;
    public float AttackFillAmount => CurrentAttack / MaxAttack;
    public float AttackSpeedFillAmount => CurrentAttackSpeed / MaxAttackSpeed;
    public ShipModel(Ship ship)
    {
        _ship = ship;
        LoadInfoBase();
    }
    public void LoadInfoBase()
    {
        _currentHealthLevel = _ship.CurrentHealthLevel;
        _currentAttackLevel = _ship.CurrentAttackLevel;
        _currentAttackSpeedLevel = _ship.CurrentAttackSpeedLevel;
    }
    public void Upgradehealth()
    {
        if (_currentHealthLevel < _ship.MaxLevel && CurrentHealth < MaxHealth)
        {
            _currentHealthLevel++;
        }
        else
        {
            return;
        }

    }
    public void UpgradeAttack()
    {
        if (_currentAttackLevel < _ship.MaxLevel && CurrentAttack< MaxAttack)
        {
            _currentAttackLevel++;
        }
        else
        {
            return;
        }
    }
    public void UpgradeAttackSpeed()
    {
        if (_currentAttackSpeedLevel < _ship.MaxLevel && CurrentAttackSpeed < MaxAttackSpeed)
        {
            _currentAttackSpeedLevel++;
        }
        else
        {
            return;
        }
    }

    public int GetHealthPrice()
    {
        return _ship.PriceUpHealth + (_ship.StepPriceMultiplier * _currentHealthLevel);
    }
    public int GetAttackPrice()
    {
        return _ship.PriceUpAttack + (_ship.StepPriceMultiplier * _currentAttackLevel);
    }
    public int GetAttackSpeedPrice()
    {
        return _ship.PriceUpAttackSpeed + (_ship.StepPriceMultiplier * _currentAttackSpeedLevel);
    }
}