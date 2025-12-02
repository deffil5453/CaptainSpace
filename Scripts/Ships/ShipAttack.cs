using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAttack : MonoBehaviour
{
    public GameObject Bullets;
    public int BulletCount = 1;
    [SerializeField] private float _attackSpeed = 0.3f;
    [SerializeField] private float _shipAttack = 10;
    public AudioSource _attackSound;
    public float GetAttack()
    {
        return _shipAttack;
    }
    public float GetAttackSpeed()
    {
        return _attackSpeed;
    }
    private void Start()
    {
        _attackSound = GetComponent<AudioSource>();
        StartCoroutine(SpaceShipAttack(_attackSpeed));
    }
    private IEnumerator SpaceShipAttack(float attackSpeed)
    {
        while (true)
        {
            if (_attackSound != null)
            {
                _attackSound.Play();
            }
            if (BulletCount > 1)
            {
                for (int i = 0; i < BulletCount; i++)
                {
                    Vector3 bulletsPosition = transform.position + new Vector3(i, 1, 0);
                    GameObject bullet = Instantiate(Bullets, bulletsPosition, Quaternion.identity);
                    BulletControl bulletControl = bullet.GetComponent<BulletControl>();
                    if (bulletControl != null)
                    {
                        bulletControl.SetDamage(_shipAttack);
                    }
                }
            }
            else
            {
                Vector3 bulletsPosition = transform.position + new Vector3(0, 1, 0);
                GameObject bullet = Instantiate(Bullets, bulletsPosition, Quaternion.identity);
                BulletControl bulletControl = bullet.GetComponent<BulletControl>();
                if (bulletControl != null)
                {
                    bulletControl.SetDamage(_shipAttack);
                }
            }
            //Vector3 bulletsPosition = transform.position + new Vector3(0, 1, 0);
            //GameObject bullet = Instantiate(Bullets, bulletsPosition, Quaternion.identity);
            //BulletControl bulletControl = bullet.GetComponent<BulletControl>();
            //if (bulletControl != null)
            //{
            //    bulletControl.SetDamage(_shipAttack);
            //}
            yield return new WaitForSeconds(attackSpeed);
        }
    }
    public void Inizialize(float attack, float attackSpeed)
    {
        _shipAttack = attack;
        _attackSpeed = attackSpeed;
    }
}
