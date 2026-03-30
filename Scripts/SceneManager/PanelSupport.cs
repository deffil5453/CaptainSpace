using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PanelSupport : MonoBehaviour
{
    public static PanelSupport Instance;
    [SerializeField] private Image ImageSupport;
    [SerializeField] private Image ImageFilled;
    //private float _duration = 0f;
    private float _currentDuration = 0f;
    private Coroutine _startTimerCoroutine;
    private void OnEnable()
    {
        SupportControl.OnSupporPickUp += StartSupportPanel;
    }
    //private void Start()
    //{
    //    ImageSupport.gameObject.SetActive(false);
    //}
    private void StartSupportPanel(SpriteRenderer image, float duration)
    {
        if (_startTimerCoroutine != null)
            StopCoroutine(_startTimerCoroutine);
        Debug.Log("ОТРАБОТАЛ");
        Debug.Log($"{duration} - ДЛИТЕЛЬНОСТЬ");
        ImageSupport.gameObject.SetActive(true);
        ImageFilled.fillAmount = 1f;
        ImageSupport.sprite = image.sprite;
        ImageSupport.color = image.color;
        Debug.Log($"{ImageSupport.sprite} - картинка");
        _startTimerCoroutine = StartCoroutine(StartPanelTimer(duration));
    }
    private IEnumerator StartPanelTimer(float duration)
    {
        while (_currentDuration < duration)
        {
            _currentDuration += Time.deltaTime;
            ImageFilled.fillAmount = 1f - (_currentDuration / duration);
            //Debug.Log(ImageFilled.fillAmount);
            yield return null;
        }
        Stop();
    }
    private void Stop()
    {
        if (_startTimerCoroutine != null)
        {
            StopCoroutine(_startTimerCoroutine);
            _startTimerCoroutine = null;
        }
        _currentDuration = 0f;
        ImageFilled.fillAmount = 1f;
        ImageSupport.gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        SupportControl.OnSupporPickUp -= StartSupportPanel;
    }
}