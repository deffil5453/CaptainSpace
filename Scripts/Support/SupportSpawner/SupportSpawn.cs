using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SupportSpawn : MonoBehaviour
{
    public List<GameObject> SupportItems = new List<GameObject>();
    [SerializeField] private float _minXSpawnPosition = -8f;
    [SerializeField] private float _maxXSpawnPosition = 8f;
    [SerializeField] private float _minSpawnDelay = 10f;
    [SerializeField] private float _maxSpawnDelay = 20f;
    private void Start()
    {
        Spawn();
    }
    private void Spawn()
    {
        int numberSupportItems = Random.Range(0, SupportItems.Count);
        float randomSpawnPosition = Random.Range(_minXSpawnPosition, _maxXSpawnPosition);
        Vector3 spawnPosition = transform.position + new Vector3(randomSpawnPosition, 0f,99f);
        Instantiate(SupportItems[numberSupportItems], spawnPosition, Quaternion.identity);
        Invoke("Spawn", Random.Range(_minSpawnDelay, _maxSpawnDelay));
    }
}
