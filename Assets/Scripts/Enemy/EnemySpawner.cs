using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    
    public float timeBetweenSpawns;
    private float nextSpawnTime;

    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + timeBetweenSpawns;
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemyPrefab, randomSpawnPoint.position, Quaternion.identity);
        }
    }
}
