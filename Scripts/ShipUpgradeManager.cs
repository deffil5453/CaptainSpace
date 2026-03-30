using DG.Tweening;
using EnumStateShip;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;
using YG.Example.DemoScene;

public class ShipUpgradeManager : MonoBehaviour
{
    [SerializeField] private ShipModel _shipModel;
    [Header("Информация о корабле")]
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _attackText;
    [SerializeField] private TMP_Text _attackSpeedText;
    [Space(10)]
    [Header("Полоски параметров")]
    [SerializeField] private Image _imageFillHealth;
    [SerializeField] private Image _imageFillAttack;
    [SerializeField] private Image _imageFillAttackSpeed;
    [Space(10)]
    [Header("Цена")]
    [SerializeField] private TMP_Text _healthPriceText;
    [SerializeField] private TMP_Text _attackPriceText;
    [SerializeField] private TMP_Text _attackSpeedPriceText;
    [Space(10)]
    [Header("Кнопки")]
    [SerializeField] private Button _upgradeHealthButton;
    [SerializeField] private Button _upgradeAttackButton;
    [SerializeField] private Button _upgradeAttackSpeedButton;

    [SerializeField] private float _showDuration = 1f;
    [SerializeField] private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup.alpha = 0f;
        _canvasGroup.blocksRaycasts = false;
        //ScinInfoInizialize();     
    }
    private void UpdateUI()
    {
        _healthText.text = _shipModel.CurrentHealth.ToString();
        _attackText.text = _shipModel.CurrentAttack.ToString();

        if (YG2.envir.language == "ru")
        {
            _attackSpeedText.text = _shipModel.CurrentAttackSpeed.ToString() + "/с";
        }
        else
        {
            _attackSpeedText.text = _shipModel.CurrentAttackSpeed.ToString("F1") + "/s";
        }
        _healthPriceText.text = "Цена: " + _shipModel.GetHealthPrice().ToString();
        _attackPriceText.text = "Цена: " + _shipModel.GetAttackPrice().ToString();
        _attackSpeedPriceText.text = "Цена: " + _shipModel.GetAttackSpeedPrice().ToString();

        _imageFillHealth.fillAmount = _shipModel.HealthFillAmount;
        _imageFillAttack.fillAmount = _shipModel.AttackFillAmount;
        _imageFillAttackSpeed.fillAmount = _shipModel.AttackSpeedFillAmount;

    }
    public void ShowWindow(ShipModel shipModel)
    {
        transform.DOKill();
        _canvasGroup.DOKill();
        _shipModel = shipModel;
        UpdateUI();
        LoadButton(shipModel.Ship.State);
        gameObject.SetActive(true);
        transform.localScale = Vector3.zero;
        _canvasGroup.DOFade(1f, _showDuration).SetEase(Ease.OutExpo);
        transform.DOScale(1f, _showDuration).SetEase(Ease.OutBack).OnComplete(() =>
        {
            _canvasGroup.blocksRaycasts = true; // разрешаем клики после появления
        });
    }
    public void CloseWindow()
    {
        SoundManager.Instance.PlaySound(SoundType.UIClick);
        _canvasGroup.blocksRaycasts = false;
        _canvasGroup.DOFade(0f, _showDuration).SetEase(Ease.InQuad);
        transform.DOScale(0f, _showDuration).SetEase(Ease.InBack).OnComplete(() =>
        {
            gameObject.SetActive(false);
        });
    }
    private void LoadButton(ShipState state)
    {
        if (state == ShipState.ReadyToBuy)
        {
            _upgradeHealthButton.gameObject.SetActive(false);
            _upgradeAttackButton.gameObject.SetActive(false);
            _upgradeAttackSpeedButton.gameObject.SetActive(false);
        }
        else
        {
            _upgradeHealthButton.gameObject.SetActive(true);
            _upgradeAttackButton.gameObject.SetActive(true);
            _upgradeAttackSpeedButton.gameObject.SetActive(true);
        }
    }
    public void BuyUpHealth()
    {
        if (!Wallet.Instance.Spend(_shipModel.GetHealthPrice()))
        {
            return;
        }
        float oldHealth = _shipModel.CurrentHealth;
        int oldPrice = _shipModel.GetHealthPrice();
        _shipModel.Upgradehealth();
        SaveShip.SaveShipData(_shipModel);
        float newPrice = _shipModel.GetHealthPrice();
        DOTween.To(() => oldPrice, x =>
        {
            _healthPriceText.text = "Цена: " + x.ToString("F0");
        }, newPrice, 0.5f);
        DOTween.To(() => oldHealth, x =>
        {
            _healthText.text = Mathf.RoundToInt(x).ToString();
            _imageFillHealth.fillAmount = x / _shipModel.MaxHealth;
        }, _shipModel.CurrentHealth, 0.5f);
        UpdateUI();

    }
    public void BuyUpAttack()
    {
        if (!Wallet.Instance.Spend(_shipModel.GetAttackPrice()))
        {
            return;
        }
        float oldAttack = _shipModel.CurrentAttack;
        int oldPrice = _shipModel.GetAttackPrice();
        _shipModel.UpgradeAttack(); 
        SaveShip.SaveShipData(_shipModel);
        float newPrice = _shipModel.GetAttackPrice();
        DOTween.To(() => oldPrice, x =>
        {
            _attackPriceText.text = "Цена: " + x.ToString("F0");
        }, newPrice, 0.5f);
        DOTween.To(() => oldAttack, x =>
        {
            _attackText.text = Mathf.RoundToInt(x).ToString("f0");
            _imageFillAttack.fillAmount = x / _shipModel.MaxAttack;
        }, _shipModel.CurrentAttack, 0.5f);
        UpdateUI();
    }
    public void BuyUpAttackSpeed()
    {
        if (!Wallet.Instance.Spend(_shipModel.GetAttackSpeedPrice()))
        {
            return;
        }

        float oldAttackSpeed = _shipModel.CurrentAttackSpeed;
        int oldPrice = _shipModel.GetAttackSpeedPrice();
        _shipModel.UpgradeAttackSpeed();
        SaveShip.SaveShipData(_shipModel);
        float newPrice = _shipModel.GetAttackSpeedPrice();
        DOTween.To(() => oldPrice, x =>
        {
            _attackSpeedPriceText.text = "Цена: " + x.ToString("F0");
        }, newPrice, 0.5f);
        DOTween.To(() => oldAttackSpeed, x =>
        {
            _attackSpeedText.text = x.ToString("F1") + "/s";
            _imageFillAttackSpeed.fillAmount = x / _shipModel.MaxAttackSpeed;
        }, _shipModel.CurrentAttackSpeed, 0.5f);
        UpdateUI();
    }
}