using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessSpawner : MonoBehaviour
{
    public GameObject groundPrefab;
    public GameObject roofPrefab;
    public GameObject cactusPrefab;
    public GameObject meteorPrefab;
    public GameObject backgroundPrefab;
    public Transform player;
    public float spawnDistance = 15f;
    private float lastSpawnX = 0f;
    private float tileLength = 15f;
    public float cactusSpawn = 0.5f;
    public float meteorSpawn = 0.5f;

    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnTile(i * tileLength);
        }
    }

    void Update()
    {
        if (player.position.x + spawnDistance > lastSpawnX)
        {
            SpawnTile(lastSpawnX);
        }
    }

    void SpawnTile(float xPos)
    {
        Instantiate(groundPrefab, new Vector2(xPos, -3f), Quaternion.identity);
        Instantiate(roofPrefab, new Vector2(xPos, 5f), Quaternion.identity);
        Instantiate(backgroundPrefab, new Vector2(xPos, 0f), Quaternion.identity);

        if (Random.value > cactusSpawn)
        {
            GameObject cactus = Instantiate(cactusPrefab, new Vector2(xPos + Random.Range(2f, 8f), -2f), Quaternion.identity);
            float randomHeight = Random.Range(0.5f, 2f);
            cactus.transform.localScale = new Vector3(1f, randomHeight, 1f);
        }

        if (Random.value > meteorSpawn)
        {
            float randomY = Random.Range(1f, 4f);
            GameObject meteor = Instantiate(meteorPrefab, new Vector2(xPos + Random.Range(2f, 8f), randomY), Quaternion.identity);
            meteor.transform.localScale = new Vector3(2f, 2f, 2f);
            meteor.AddComponent<MeteorPhysics>();
        }

        lastSpawnX += tileLength;
    }
}