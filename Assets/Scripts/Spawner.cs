using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval = 3f;
    public float spawnRadius = 10f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnEnemyRoutine());
    }

    IEnumerator SpawnEnemyRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        if (player != null && enemyPrefab != null)
        {
            Vector2 spawnDirection = Random.insideUnitCircle.normalized;
            Vector2 spawnPosition = (Vector2)player.position + spawnDirection * spawnRadius;

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }
    }
}
