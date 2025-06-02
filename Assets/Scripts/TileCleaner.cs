using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileCleaner : MonoBehaviour
{
    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player != null && transform.position.x + 20f < player.position.x)
        {
            Destroy(gameObject);
        }
    }
}
