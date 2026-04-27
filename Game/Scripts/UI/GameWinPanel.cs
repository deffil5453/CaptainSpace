using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class GameWinPanel : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    private int _rewardWin = 0;
    [SerializeField] private TMP_Text _rewardText;
    private void Start()
    {
       //GameManager.instance.OnGameWin += ShowWindow;
        Debug.Log("подписался");
        _canvasGroup.alpha = 0f;
        _canvasGroup.blocksRaycasts = false;
        _rewardWin = GameManager.instance.KillEnemyToWin * 4;
        ShowWindow();
        //ScinInfoInizialize();     
    }
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SoundManager.Instance.PlaySound(SoundType.UIClick);
        //Time.timeScale = 0;
        Wallet.Instance.Add((int)_rewardWin);
        YG2.InterstitialAdvShow();

        SceneManager.LoadScene("Menu");
    }
    public void BackToMenuReward()
    {
        Time.timeScale = 1f;
        SoundManager.Instance.PlaySound(SoundType.UIClick);
        //Time.timeScale = 0;
        //YG2.InterstitialAdvShow();
        YG2.RewardedAdvShow("x2Reward");
        Wallet.Instance.Add((int)_rewardWin * 2);
        SceneManager.LoadScene("Menu");
    }
    public void ShowWindow()
    {
        transform.DOKill();
        _canvasGroup.DOKill();
        //gameObject.SetActive(true);
        transform.localScale = Vector3.zero;
        _canvasGroup.DOFade(1f, 1f).SetEase(Ease.OutExpo);
        DOTween.To(() => 0, x =>
        {
            _rewardText.text = $"{x}";

        }, _rewardWin, 1f);
        _rewardText.text = $"{_rewardWin}";
        transform.DOScale(1f, 1f).SetEase(Ease.OutBack).OnComplete(() =>
        {
            _canvasGroup.blocksRaycasts = true; // разрешаем клики после появления
        });
        
    }
}
