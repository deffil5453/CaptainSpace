using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class ScinInfo : MonoBehaviour
{
    [Header("Информация о корабле")]
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _attackText;
    [SerializeField] private TMP_Text _attackSpeedText;


    //[Header("Кнопки прокачки корабля")]
    //[SerializeField] private Button _healthUpButton;
    //[SerializeField] private Button _attackUpButton;
    //[SerializeField] private Button _attackSpeedUpButton;

    //[SerializeField] private Animator _animator;
    [SerializeField] private Ship _ship;
    public Button OpenAnimationButton;
    private void Awake()
    {
        _ship = GetComponentInParent<ScinShipControl>().Ship;
        //_animator = GetComponent<Animator>();
        _healthText = transform.Find("HealthBlock").Find("HealthText").GetComponent<TMP_Text>();
        _attackText = transform.Find("AttackBlock").Find("AttackText").GetComponent<TMP_Text>();
        _attackSpeedText = transform.Find("AttackSpeedBlock").Find("AttackSpeedText").GetComponent<TMP_Text>();
    }
    private void Start()
    {
        transform.DOScale(transform.localScale, 0.5f);
        ScinInfoInizialize();
        EventsManager.UpEvent += OnStatsUpdate;
    }
    private void OnStatsUpdate(int value)
    {
        ScinInfoInizialize();
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
    }


    public void OpenAnimator()
    {
        gameObject.SetActive(true);
    }
    public void CloseAnimator()
    {
        string animationName = "CloseScinInfo";
        StartCoroutine(CloseAnimationTime(animationName, 0.5f));

    }
    private IEnumerator CloseAnimationTime(string animationName, float time)
    {
        //_animator.Play(animationName);
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
        OpenAnimationButton.gameObject.SetActive(true);
    }
    private void OnDestroy()
    {
        EventsManager.UpEvent -= OnStatsUpdate;
    }
}