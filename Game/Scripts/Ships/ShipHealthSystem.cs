using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipHealthSystem : MonoBehaviour
{
    [SerializeField] private float _currenHealth;
    private float _maxHealth;
    public Image Bar;
    public float GetHealth()
    {
        return _currenHealth;
    }
    private void Start()
    {
        _maxHealth = _currenHealth;
        AddHealEvent.OnHealthChanged += SetHealth;
    }
    public IEnumerator ChangeHealth(float amount, float duration)
    {
        // Устанавливаем целевое здоровье, ограничивая его от 0 до 100
        float targetHealth = Mathf.Clamp(_currenHealth + amount, 0f, _maxHealth);

        float elapsed = 0f;

        // Плавно изменяем текущее здоровье
        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            _currenHealth = Mathf.Lerp(_currenHealth, targetHealth, elapsed / duration);
            Bar.fillAmount = _currenHealth / _maxHealth; // Обновляем полосу здоровья
            yield return null; // Ждем следующего кадра
        }

        // Устанавливаем окончательное значение здоровья
        _currenHealth = targetHealth;
        Bar.fillAmount = _currenHealth / _maxHealth; // Обновляем полосу здоровья в конце
        // Проверяем, если здоровье меньше или равно 0, вызываем PlayerDead
        if (_currenHealth<=0)
        {
            GameManager.instance.PlayerDead();
        }
    }
    public void SetHealth(float amount)
    {

        StartCoroutine(ChangeHealth(amount, 0.1f));
    }
    public void SetFullHealth()
    {
        SetHealth(_maxHealth);
    }
    private void OnDestroy()
    {
        AddHealEvent.OnHealthChanged -= SetHealth;
    }
    public void Inizialize(float currenHealth)
    {
        _currenHealth = currenHealth;
    }
}