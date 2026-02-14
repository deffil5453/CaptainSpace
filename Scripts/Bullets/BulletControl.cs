using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public ParticleSystem DestroyEffect;
    private float _currentDamage;
    private byte _countPierce = 3;
    private bool _isPierce = false;
    public bool IsPierce
    {
        get { return _isPierce; }
        set { _isPierce = value; }
    }
    private HashSet<GameObject> _alreadyHit = new HashSet<GameObject>();
    public void Inizialize(float damage, bool isPierce = false)
    {
        _currentDamage = damage;
        _isPierce = isPierce;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !_alreadyHit.Contains(collision.gameObject))
        {
            Debug.Log(collision.gameObject.name);
            EnemyControl enemyControl = collision.gameObject.GetComponent<EnemyControl>();
            if (enemyControl != null)
            {
                enemyControl.TakeDamage(_currentDamage);
                _alreadyHit.Add(collision.gameObject);
                if (_isPierce)
                {
                    _countPierce--;
                    if (_countPierce<=0)
                    {
                        Destroy(gameObject);
                    }
                }
                else
                {
                    Destroy(gameObject);
                }
            }
            Instantiate(DestroyEffect, transform.position, Quaternion.identity);
        }
        if (collision.gameObject.CompareTag("Healthler"))
        {
            HealControl healControl = collision.gameObject.GetComponent<HealControl>();
            if (healControl != null)
            {
                healControl.SummingHealth(_currentDamage);
            }
        }
        //Destroy(gameObject);
    }
}
