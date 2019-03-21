using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject zombie;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    void Start()
    {
        // eftir 3 sek er kallad a Spawn fallid hverjar 3 sek
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        // Ef player er ekki daudur heldur afram ad spawn-a
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        Instantiate(zombie, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
