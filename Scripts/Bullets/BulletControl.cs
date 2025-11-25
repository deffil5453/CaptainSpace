using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    private float _currentDamage;
    public float SetDamage(float damage)
    {
        return _currentDamage = damage;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log(collision.gameObject.name);
            EnemyControl enemyControl = collision.gameObject.GetComponent<EnemyControl>();
            if (enemyControl != null)
            {
                enemyControl.TakeDamage(_currentDamage);
            }
            //Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Healthler"))
        {
            HealControl healControl = collision.gameObject.GetComponent<HealControl>();
            if (healControl != null)
            {
                healControl.SummingHealth(_currentDamage);
            }
        }
        Destroy(gameObject);
    }
}
