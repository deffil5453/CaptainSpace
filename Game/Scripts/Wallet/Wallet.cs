using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerPrefs = RedefineYG.PlayerPrefs;
public class Wallet : MonoBehaviour
{
    public static Wallet Instance;
    public int Money { get; set; }
    private int _oldMoney;
    public event Action<int, int> OnMoneyChanged;
    public event Action<int, int> OnMoneyLoadChanged;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        LoadMoney();
    }
    private void LoadMoney()
    {
        Money = PlayerPrefs.GetInt("PlayerMoney", 0);
    }
    private void SaveMoney()
    {
        PlayerPrefs.SetInt("PlayerMoney", Money);
        PlayerPrefs.Save();
    }
    public bool Spend(int amout)
    {
        if (amout <= Money)
        {
            _oldMoney = Money;
            Money -= amout;
            SaveMoney();
            OnMoneyChanged?.Invoke(_oldMoney, Money);
            return true;
        }
        return false;
    }
    public void Add(int amount)
    {
        _oldMoney = Money;
        Money += amount;
        SaveMoney();
        OnMoneyChanged?.Invoke(_oldMoney, Money);
    }
}
