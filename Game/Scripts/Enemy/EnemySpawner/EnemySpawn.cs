using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] Enemies;

    [SerializeField] private float _minXSpawnPosition = -8f;
    [SerializeField] private float _maxXSpawnPosition = 8f;
    [SerializeField] private float _minSpawnDelay = 0.5f;
    [SerializeField] private float _maxSpawnDelay = 1.7f;
    public ParticleSystem DestroyEffect;
    private int currentWave => PlayerPrefs.GetInt("LevelWafe"); // безопасное чтение с дефолтом = 1

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        // 🔑 Определяем максимальный индекс врага, доступный на этой волне
        int maxEnemyTier = Mathf.Min(Enemies.Length - 1, (currentWave - 1) / 3); // каждые 3 волны открывается новый уровень

        // Случайный выбор врага от 0 до maxEnemyTier (включительно)
        int enemyIndex = Random.Range(0, maxEnemyTier + 1);

        float randomSpawnPosition = Random.Range(_minXSpawnPosition, _maxXSpawnPosition);
        Vector3 spawnPosition = transform.position + new Vector3(randomSpawnPosition, 0f, 0f);

        GameObject enemy = Instantiate(Enemies[enemyIndex], spawnPosition, Quaternion.identity);
        enemy.GetComponent<EnemyControl>().DestroyEffect = DestroyEffect;

        Invoke("Spawn", Random.Range(_minSpawnDelay, _maxSpawnDelay));
    }
}