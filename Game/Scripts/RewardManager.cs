using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using TMPro;
using UnityEngine;
using YG;

public class RewardManager : MonoBehaviour
{
    public static RewardManager Instance;
    [SerializeField] private GameObject _rewardFullBlock;
    [SerializeField] private float _timer = 120f;
    [SerializeField] private TextMeshProUGUI _rewardMoneyText;
    private int _rewardMoney = 50;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        _rewardFullBlock.SetActive(true);
    }
    private void Start()
    {
        //Wallet.Instance.OnMoneyChanged += UpdateRewardMoney;
        Inizialize();
    }
    private void Inizialize()
    {
        Debug.Log(PlayerPrefs.GetInt("LevelWafe"));
        _rewardMoney *= PlayerPrefs.GetInt("LevelWafe");
        if (YG2.lang == "ru")
        {
            _rewardMoneyText.text = $"бесплатно {_rewardMoney} монет";
        }
        else
        {
            _rewardMoneyText.text = $"free {_rewardMoney} coin";
        }
    }
    public void AdvRewardMoney()
    {
        YG2.RewardedAdvShow("1", () =>
        {
            Wallet.Instance.Add(_rewardMoney);
            _rewardFullBlock.SetActive(false);
            StartCoroutine(StartTimer());
        });
    }
    private IEnumerator StartTimer()
    {
        while (_timer > 0)
        {
            _timer -= Time.deltaTime;
            UpdateTimerText();
            yield return null;
        }
        _rewardFullBlock.SetActive(true);
        if (YG2.lang == "ru")
        {
            _rewardMoneyText.text = $"бесплатно {_rewardMoney} монет";
        }
        else
        {
            _rewardMoneyText.text = $"free {_rewardMoney} coin";
        }
    }
    private void UpdateTimerText()
    {
        float minutes = Mathf.FloorToInt(_timer / 60);
        float seconds = Mathf.FloorToInt(_timer % 60);

        _rewardMoneyText.text = string.Format($"{minutes:00} : {seconds:00}");
    }
    //private void UpdateRewardMoney(int minvalue, int maxValue)
    //{
    //    DOTween.To(() => minvalue, x =>
    //    {
    //        _rewardMoneyText.text = x.ToString();
    //        _rewardMoney = x;
    //    }, maxValue, 1.5f);
    //}
    //private void OnDestroy()
    //{
    //    Wallet.Instance.OnMoneyChanged -= UpdateRewardMoney;
    //}
}
