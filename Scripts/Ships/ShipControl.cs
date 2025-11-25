using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShipControl : MonoBehaviour
{
    public GameManager GameManager;

    [SerializeField] private bool _isInvulnerable;
    private Coroutine _isInvulnerabilityCoroutine;
    public GameObject InvulnerableAnimator;
    private ShipHealthSystem _healthSystem;
    public Image Bar;

    private void Start()
    {
        _healthSystem = GetComponent<ShipHealthSystem>();
        GameManager = FindFirstObjectByType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyControl enemyControl = collision.gameObject.GetComponent<EnemyControl>();
            if (!_isInvulnerable)
            {
                StartCoroutine(_healthSystem.ChangeHealth(-10f, 0.1f, Bar));
                if (_healthSystem.GetHealth() <= 0)
                {
                    GameManager.PlayerDead();
                }
            }
            enemyControl.EnemyDead();

        }
        else if (collision.gameObject.CompareTag("Healthler"))
        {
            HealControl healControl = collision.gameObject.GetComponent<HealControl>();
            if (healControl != null)
            {
                StartCoroutine(_healthSystem.ChangeHealth(healControl.GetHealth(), 1.5f, Bar));
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Invunerable"))
        {
            InvunerabilityControl invunerability = collision.gameObject.GetComponent<InvunerabilityControl>();
            Destroy(collision.gameObject);

            // Если уже есть активная корутина, останавливаем её
            if (_isInvulnerabilityCoroutine != null)
            {
                StopCoroutine(_isInvulnerabilityCoroutine);
            }

            _isInvulnerable = true; // Устанавливаем неуязвимость
            _isInvulnerabilityCoroutine = StartCoroutine(InvulnerabilityDuration(invunerability.GetInvunerabilityDuration())); // Запускаем новую корутину
        }
    }
    
    private IEnumerator InvulnerabilityDuration(float timeDuration)
    {
        InvulnerableAnimator.SetActive(true);
        yield return new WaitForSeconds(timeDuration);
        _isInvulnerable = false;
        InvulnerableAnimator.SetActive(false);
    }
}