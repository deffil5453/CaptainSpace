
using UnityEngine;

public class ShipControl : MonoBehaviour
{
    public GameManager GameManager;

    [SerializeField] private bool _isInvulnerable;
    //[SerializeField] private bool _isMultiShotActive;
    //public GameObject InvulnerableAnimator;

    private ShipHealthSystem _healthSystem;
    //public Image Bar;
    [SerializeField] private ShipAttack _shipAttack;
    public ShipAttack ShipAttack
    {
        get { return _shipAttack; }
        set { _shipAttack = value; }
    }
    public bool IsInvul
    {
        get
        {
            return _isInvulnerable;
        }
        set
        {
            _isInvulnerable = value;
        }
    }
    //public int BulletCount
    //{
    //    get
    //    {
    //        return _shipAttack.BulletCount;
    //    }
    //    set
    //    {
    //        _shipAttack.BulletCount = value;
    //    }
    //}
    private void Start()
    {
        _shipAttack = GetComponent<ShipAttack>();
        _healthSystem = GetComponent<ShipHealthSystem>();
        GameManager = FindFirstObjectByType<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(collision.gameObject);
            EnemyControl enemyControl = collision.gameObject.GetComponent<EnemyControl>();
            if (!_isInvulnerable)
            {
                StartCoroutine(_healthSystem.ChangeHealth(-10f, 0.1f));
                if (_healthSystem.GetHealth() <= 0)
                {
                    GameManager.PlayerDead();
                }
            }
            enemyControl.EnemyDead();

        }
        else if (collision.gameObject.CompareTag("Support"))
        {
            SupportManager.Instance.SupportActive(collision.gameObject, this);
            Destroy(collision.gameObject);
        }
        //else if (collision.gameObject.CompareTag("Healthler"))
        //{
        //    HealControl healControl = collision.gameObject.GetComponent<HealControl>();
        //    if (healControl != null)
        //    {
        //        StartCoroutine(_healthSystem.ChangeHealth(healControl.GetHealth(), 1.5f, Bar));
        //    }
        //    Destroy(collision.gameObject);
        //}
        //else if (collision.gameObject.CompareTag("Invunerable"))
        //{
        //    InvunerabilityControl invunerability = collision.gameObject.GetComponent<InvunerabilityControl>();
        //    Destroy(collision.gameObject);

        //    // Если уже есть активная корутина, останавливаем её
        //    if (_isInvulnerabilityCoroutine != null)
        //    {
        //        StopCoroutine(_isInvulnerabilityCoroutine);
        //    }

        //    _isInvulnerable = true; // Устанавливаем неуязвимость
        //    _isInvulnerabilityCoroutine = StartCoroutine(InvulnerabilityDuration(invunerability.Duration)); // Запускаем новую корутину
        //}
        //else if (collision.gameObject.CompareTag("MultiShot"))
        //{
        //    MultiShootScript multiShootScript = collision.gameObject.GetComponent<MultiShootScript>();
        //    Destroy(collision.gameObject);

        //    _shipAttack.BulletCount = 2;
        //    _isMultiShotActive = true;
        //    StartCoroutine(MultiShootDuration(multiShootScript.Duration));
        //}
    }

    //public IEnumerator MultiShootDuration(float timeDuration)
    //{
    //    yield return new WaitForSeconds(timeDuration);
    //    //_isMultiShotActive = false;
    //    _shipAttack.BulletCount = 1;
    //}
    //private IEnumerator InvulnerabilityDuration(float timeDuration, AnimatorController invulAnimator)
    //{
    //    //InvulnerableAnimator.SetActive(true);
    //    //invulAnimator.startAn

    //    yield return new WaitForSeconds(timeDuration);
    //    _isInvulnerable = false;
    //    //InvulnerableAnimator.SetActive(false);
    //}
}