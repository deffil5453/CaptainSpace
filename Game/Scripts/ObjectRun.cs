using UnityEngine;

public class ObjectRun : MonoBehaviour
{
    [SerializeField] private float _currentSpeed;
    [SerializeField] private float _lifeTime = 30f;
    private void Start()
    {
        Destroy(gameObject, _lifeTime);
    }
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(new Vector3(0, -_currentSpeed * Time.deltaTime, 0));
    }
}
