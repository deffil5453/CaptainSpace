using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class ShipUpgradeManager : MonoBehaviour
{
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
    [SerializeField] private TMP_Text _healthPriceText;
    [SerializeField] private TMP_Text _attackPriceText;
    [SerializeField] private TMP_Text _attackSpeedPriceText;
    [SerializeField] private float _showDuration = 1f;
    [SerializeField] private CanvasGroup _canvasGroup;

    [SerializeField] private Ship _ship;
    private void Start()
    {
        _canvasGroup.alpha = 0f;
        _canvasGroup.blocksRaycasts = false;
        //ScinInfoInizialize();
        //Debug.Log(_ship);
        //_healthText = transform.Find("HealthBlock").Find("HealthText").GetComponent<TMP_Text>();
        //_attackText = transform.Find("AttackBlock").Find("AttackText").GetComponent<TMP_Text>();
        //_attackSpeedText = transform.Find("AttackSpeedBlock").Find("AttackSpeedText").GetComponent<TMP_Text>();
    }
    private void ScinInfoInizialize()
    {
        _healthText.text = _ship.BaseHealth.ToString();
        _attackText.text = _ship.BaseAttack.ToString();


        if (YG2.envir.language == "ru")
        {
            _attackSpeedText.text = _ship.BaseAttackSpeed.ToString() + "/с";
        }
        else
        {
            _attackSpeedText.text = _ship.BaseAttackSpeed.ToString() + "/s";
        }
        _healthPriceText.text = "Цена: "+_ship.PriceUpHealth.ToString();
        _attackPriceText.text ="Цена: "+ _ship.PriceUpAttack.ToString();
        _attackSpeedPriceText.text ="Цена: "+ _ship.PriceUpAttackSpeed.ToString();

        _imageFillHealth.fillAmount = _ship.BaseHealth/_ship.MaxHealth;
        _imageFillAttack.fillAmount = _ship.BaseAttack / _ship.MaxAttack;
        _imageFillAttackSpeed.fillAmount = _ship.BaseAttackSpeed / _ship.MaxAttackSpeed;
    }
    public void ShowWindow(Ship ship)
    {
        transform.DOKill();
        _canvasGroup.DOKill();
        _ship = ship;
        ScinInfoInizialize();
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
        //_ship = null;
    }
    public void BuyUpHealth()
    {
        if (MenuManager.TotalMoney < _ship.PriceUpHealth)
        {
            return;
        }

        _ship.BaseHealth += 20;
        _ship.CurrentHealthLevel++;
        EventsManager.UpActivation(-_ship.PriceUpHealth); ScinInfoInizialize();
    }
    public void BuyUpAttack()
    {
        if (MenuManager.TotalMoney < _ship.PriceUpAttack)
        {
            return;
        }
        _ship.BaseAttack += 1;
        _ship.CurrentAttackLevel++;
        EventsManager.UpActivation(-_ship.PriceUpAttack); ScinInfoInizialize();
    }
    public void BuyUpAttackSpeed()
    {
        if (MenuManager.TotalMoney < _ship.PriceUpAttackSpeed)
        {
            return;
        }
        _ship.BaseAttackSpeed += 1f;
        _ship.CurrentAttackSpeedLevel++;
        EventsManager.UpActivation(-_ship.PriceUpAttackSpeed); ScinInfoInizialize();
    }
}
