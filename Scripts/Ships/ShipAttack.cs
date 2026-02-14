using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipAttack : MonoBehaviour
{
    public GameObject Bullets;
    public int BulletCount = 1;
    public bool IsPiercing = false;
    [SerializeField] private float _attackSpeed = 0.3f;
    [SerializeField] private float _shipAttack = 10;
    private float _lengthAttackSpawnBullet = 1f;
    public AudioSource _attackSound;
    private BulletControl bulletControl;
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
                //print(step);
                MultiShot();
            }
            else
            {
                Vector3 bulletsPosition = transform.position + new Vector3(0, 1, 0);
                GameObject bullet = Instantiate(Bullets, bulletsPosition, Quaternion.identity);
                BulletInit(bullet);
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

    private void BulletInit(GameObject bullet)
    {
        bulletControl = bullet.GetComponent<BulletControl>();
        if (bulletControl != null)
        {
            bulletControl.Inizialize(_shipAttack, IsPiercing);
        }
    }

    private void MultiShot()
    {
        float step = _lengthAttackSpawnBullet / (BulletCount - 1);
        for (int i = 0; i < BulletCount; i++)
        {
            float xOffset = (-_lengthAttackSpawnBullet / 2) + i * step;
            //print(xOffset);
            Vector3 bulletsPosition = transform.position + new Vector3(xOffset, 1, 0);
            GameObject bullet = Instantiate(Bullets, bulletsPosition, Quaternion.identity);
            BulletInit(bullet);
        }
    }

    public void Inizialize(float attack, float attackSpeed)
    {
        _shipAttack = attack;
        _attackSpeed = 1/attackSpeed;
    }
}