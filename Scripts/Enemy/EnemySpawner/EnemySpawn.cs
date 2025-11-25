using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] Enemies = new GameObject[1];

    [SerializeField] private float _minXSpawnPosition = -8f;
    [SerializeField] private float _maxXSpawnPosition = 8f;
    [SerializeField] private float _minSpawnDelay = 0.5f;
    [SerializeField] private float _maxSpawnDelay = 1.9f;
    public ParticleSystem DestroyEffect;
    private void Start()
    {
        Spawn();
    }
    private void Spawn()
    {
        int randomNumberEnemies = Random.Range(0, Enemies.Length);
        float randomSpawnPosition = Random.Range(_minXSpawnPosition, _maxXSpawnPosition);
        Vector3 spawnPosition = transform.position + new Vector3(randomSpawnPosition, 0f, 100f);
        GameObject enemy = Instantiate(Enemies[randomNumberEnemies], spawnPosition, Quaternion.identity);
        enemy.GetComponent<EnemyControl>().DestroyEffect = DestroyEffect;
        Invoke("Spawn", Random.Range(_minSpawnDelay, _maxSpawnDelay));
    }
}