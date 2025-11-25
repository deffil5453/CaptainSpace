using EnumStateShip;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;


public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;
    [SerializeField] private TMP_Text _totalMoneyText;
    [SerializeField] private TMP_Text _maxScoreText;
    public static int TotalMoney = 0;
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
        Skins = new List<ScinShipControl>(FindObjectsOfType<ScinShipControl>());
    }
    private void Start()
    {
        if (YG2.envir.language == "ru")
        {
            _maxScoreText.text = $"¬аш лучший счЄт: {PlayerPrefs.GetInt("MaxScore")}";
        }
        else
        {
            _maxScoreText.text = $"Your best score: {PlayerPrefs.GetInt("MaxScore")}";
        }


        //PlayerPrefs.DeleteAll();
        LoadMoney();
        EventsManager.UpEvent += UpdateMoney;
        //LoadBuySkin();

    }
    private void Update()
    {
        //LoadBuySkin();
    }
    public void StartGame()
    {
        YG2.InterstitialAdvShow();
        SceneManager.LoadScene("Game");
    }
    public void BackToMenu()
    {
        YG2.InterstitialAdvShow();
        SceneManager.LoadScene("Menu");
    }
    public void LoadMoney()
    {
        Debug.Log(PlayerPrefs.GetInt("PlayerMoney", 0));
        Debug.Log(TotalMoney);
        TotalMoney = PlayerPrefs.GetInt("PlayerMoney", 0);
        //TotalMoney = 1000;
        UpdateMoneyText();
    }

    public void UpdateMoneyText()
    {
        _totalMoneyText.text = TotalMoney.ToString();
    }
    public void AdvRewardMoney()
    {
        YG2.RewardedAdvShow("1", () =>
        {
            UpdateMoney(50);

        });
    }
    private void UpdateMoney(int value)
    {
        TotalMoney += value;
        PlayerPrefs.SetInt("PlayerMoney", TotalMoney);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("PlayerMoney"));
        UpdateMoneyText();
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
    private void LoadBuySkin()
    {
        if (Skins.Count <= 1)
        {
            return;
        }
        //for (int i = 0; i < Skins.Count; i++)
        //{

        //    if (PlayerPrefs.GetInt(Skins[i].Sprite + "IsBuy") == i)
        //    {
        //        Skins[i].IsBuy = true;
        //    }

        //    if (Skins[i].IsBuy)
        //    {
        //        Skins[i].BuyButton.gameObject.SetActive(false);
        //        Skins[i].SelectedButton.gameObject.SetActive(true);
        //    }
        //    else
        //    {
        //        Skins[i].BuyButton.gameObject.SetActive(true);
        //        Skins[i].SelectedButton.gameObject.SetActive(false);
        //    }

        //    if (PlayerPrefs.GetInt("IsSelected") == i)
        //    {
        //        Skins[i].IsSelected = true;
        //        Skins[i].SelectedButton.gameObject.SetActive(false);
        //    }
        //    //else
        //    //{
        //    //    Skins[i].IsSelected = false;
        //    //    Skins[i].SelectedButton.gameObject.SetActive(true);
        //    //}
        //}
    }
    private void OnDestroy()
    {
        EventsManager.UpEvent -= UpdateMoney;
    }
    public void DeleteAllSaves()
    {
        PlayerPrefs.DeleteAll();
        RestartScene();
    }
    private void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
