using DG.Tweening;
using EnumStateShip;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;


public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField] private TMP_Text _totalMoneyText;
    [SerializeField] private TMP_Text _maxScoreText;
    [SerializeField] private TMP_Text _purposeText;
    private int _oldMoney;
    private int _wafeLevel = 1;
    private int _purposeToDestroyWave;
    private int _totalEnemyDestroyed = 0;
    public List<ScinShipControl> Skins;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        //PlayerPrefs.DeleteAll();
        Skins = new List<ScinShipControl>(FindObjectsOfType<ScinShipControl>());
        _oldMoney = 0;
    }
    private void Start()
    {
        _purposeToDestroyWave = (6 * PlayerPrefs.GetInt("LevelWafe", 1)) / 2;
        _totalEnemyDestroyed += PlayerPrefs.GetInt("MaxScore", 0);
        if (YG2.envir.language == "ru")
        {
            _maxScoreText.text = $"Всего уничтожено: {_totalEnemyDestroyed}";
            _purposeText.text = $"Цель: уничтожить {_purposeToDestroyWave} монстров";
            
        }
        else
        {
            _maxScoreText.text = $"Everything is destroyed: {_totalEnemyDestroyed}";
            _purposeText.text = $"Purpose: to destroy {_purposeToDestroyWave} monsters";
        }


        Wallet.Instance.OnMoneyChanged += UpdateMoney;
        LoadMoney();
    }
    private void Update()
    {
        //LoadBuySkin();
        if (Input.GetKeyDown(KeyCode.M))
        {
            Wallet.Instance.Add(1000);
        }
    }
    public void StartGame()
    {
        SoundManager.Instance.PlaySound(SoundType.UIClick);
        YG2.InterstitialAdvShow();
        _wafeLevel++;
        SceneManager.LoadScene("Game");
    }
    public void BackToMenu()
    {
        SoundManager.Instance.PlaySound(SoundType.UIClick);
        YG2.InterstitialAdvShow();
        SceneManager.LoadScene("Menu");
    }
    public void LoadMoney()
    {
        //TotalMoney = 1000;
        UpdateMoney(0, Wallet.Instance.Money);
    }

    public void AdvRewardMoney()
    {
        RewardManager.Instance.AdvRewardMoney(50);
    }
    private void UpdateMoney(int minvalue, int maxValue)
    {
        DOTween.To(() => minvalue, x =>
        {
            _totalMoneyText.text = x.ToString();
            _oldMoney = x;
        }, maxValue, 0.5f);
    }
    public void ResetShip()
    {
        foreach (var item in Skins)
        {
            if (item.State == ShipState.Selected)
            {
                item.Buy(false);
            }
        }
    }
    private void OnDestroy()
    {
        Wallet.Instance.OnMoneyChanged -= UpdateMoney;
    }
    public void DeleteAllSaves()
    {
        PlayerPrefs.DeleteAll();
        RestartScene();
    }
    public void ExitGame()
    {
        Application.Quit(); 
    }
    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
