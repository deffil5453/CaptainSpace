using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletsMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _lifeTime;
    private void Start()
    {
        Move();
        Destroy(gameObject, _lifeTime);
    }
    private void Move()
    {
        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();   
        rigidbody.velocity = new Vector2(0f, _speed);
        //transform.position += new Vector3(0f, _speed*Time.deltaTime, 0f);
    }
}
