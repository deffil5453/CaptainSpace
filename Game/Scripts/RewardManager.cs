using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class RewardManager : MonoBehaviour
{
    public static RewardManager Instance;
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
    }
    public void AdvRewardMoney(int amount = 50)
    {
        YG2.RewardedAdvShow("1", () =>
        {
            Wallet.Instance.Add(amount);
        });
    }
}
