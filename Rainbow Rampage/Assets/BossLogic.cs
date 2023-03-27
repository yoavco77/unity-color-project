using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLogic : MonoBehaviour
{
    public GameObject Missle;

    public float attackCountdown;
    public float attackRate;

    public float missleSpawnRadius = 3f;

    void Start()
    {
        attackCountdown = attackRate;
    }

    void Update()
    {
        attackCountdown -= Time.deltaTime;

        if (attackCountdown <= 0)
        {
            spawnMissles();
            attackCountdown = attackRate;
        }
    }
    void spawnMissles()
    {
        
        int randomMissleAmount = Random.Range(4, 8);
        
        while (randomMissleAmount != 0)
        {
            Vector3 spawnPoint = transform.position + Random.insideUnitSphere * missleSpawnRadius;
            Instantiate(Missle, spawnPoint, transform.rotation);
            randomMissleAmount -= 1;
        }

    }

    
}
