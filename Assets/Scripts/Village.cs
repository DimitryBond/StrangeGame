using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Village : MonoBehaviour
{
    public GameObject workerPrefab;
    public Transform spawnPoint;

    public float timeBetweenSpawn;
    private float nextSpawnTime;
    public int numberOfWorkersToSpawn;

    private void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + timeBetweenSpawn;
            Instantiate(workerPrefab, spawnPoint.position, Quaternion.identity);

            if (numberOfWorkersToSpawn <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
