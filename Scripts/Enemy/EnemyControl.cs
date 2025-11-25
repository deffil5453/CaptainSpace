using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour
{
    [SerializeField] private float _currentHealth = 100f;
    private float _segmentBar;
    [SerializeField] private int _enemyLevel = 1;
    private bool _isDead = false;
    private SpriteRenderer _sprite;
    public AudioClip DeadSound;
    public Image Bar;
    public ParticleSystem DestroyEffect;
    private bool isGameFocused = true;
    private void Start()
    {
        _sprite = GetComponent<SpriteRenderer>();
        _currentHealth += _enemyLevel * _currentHealth / 4;
        _segmentBar = _currentHealth;
    }
    public void TakeDamage(float damage)
    {
        if (_isDead) { return; }
        
        _currentHealth -= damage;
        StartCoroutine(HandleTakeAttack(0.2f));
        if (_currentHealth <= 0)
        {
            EnemyDead();
        }
        else
        {
            Bar.fillAmount = _currentHealth / _segmentBar;
        }
    }

    public void EnemyDead()
    {
        if (_isDead) { return; }

        GameManager gameManager = FindAnyObjectByType<GameManager>();
        gameManager.AddScore(_enemyLevel);
        _isDead = true;
        StartCoroutine(HandleDeath());

    }
    private IEnumerator HandleTakeAttack(float time)
    {
        _sprite.color = new Color(172f,0f,0f);
        yield return new WaitForSeconds(time);
        _sprite.color = Color.white;
    }
    private IEnumerator HandleDeath()
    {
        Destroy(gameObject);
        if (DeadSound != null && isGameFocused)
        {
            GameObject soundObject = new GameObject("DeadSound");
            AudioSource audioSource = soundObject.AddComponent<AudioSource>();
            audioSource.clip = DeadSound;
            audioSource.volume = 0.2f; // Установите желаемую громкость
            audioSource.Play();

            // Уничтожаем объект звука после завершения воспроизведения
            Destroy(soundObject, DeadSound.length);
        }
        Instantiate(DestroyEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(DestroyEffect.main.duration);
    }
    private void OnApplicationPause(bool pause)
    {
        isGameFocused = pause;
    }
}