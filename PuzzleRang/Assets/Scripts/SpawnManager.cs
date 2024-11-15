using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject player;
    private GameObject[] enemies;
    public float enemySpeed = 50f;

    private float spawnRange = 22;
    private float platformOffsetX = 0;
    private float enemiesToSpawn;
    private int waveNumber = 1;

    // Distance around the player where enemies cannot spawn
    public float spawnCushionRadius = 5f;

    void Start()
    {
        enemiesToSpawn = 3;
        SpawnEnemyWave();
    }

    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length <= 0)
        {
            SpawnEnemyWave();

            if (waveNumber >= 3)
            {
                enemySpeed += 5;
            }
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        Vector3 randomPos;
        float playerZ = player.transform.position.z;

        // Loop until a valid spawn position is found
        do
        {
            float spawnPosX = UnityEngine.Random.Range(-spawnRange + platformOffsetX, spawnRange + platformOffsetX);
            float spawnPosZ = UnityEngine.Random.Range(playerZ + 5f, playerZ + 40f);
            
            // Generate position at or above the player's Y position
            randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        }
        // Check both the cushion radius and the height condition
        while (Vector3.Distance(new Vector3(randomPos.x, 0, playerZ), player.transform.position) < spawnCushionRadius);
        return randomPos;
    }

    private void SpawnEnemyWave()
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            
            if (enemyScript != null)
            {
                enemyScript.speed = enemySpeed;
            }
        }
        enemiesToSpawn += 2;
        waveNumber++;
    }
}
