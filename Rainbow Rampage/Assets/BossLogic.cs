using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static WaveSystem;

public class BossLogic : MonoBehaviour
{
    public GameObject Missle;

    public float attackCountdown;
    public float attackRate;


    public float missleSpawnRadius = 3f;
    public float missleAttackRate = 0.05f;
    
    void Start()
    {
        attackCountdown = attackRate;
    }

    void Update()
    {
        //waiting to attack
        if (attackCountdown <= 0)
        {
            StartCoroutine(SpawnMissles());
            attackCountdown = attackRate;
        }
        else
        {
            attackCountdown -= Time.deltaTime;
        }


    }



    IEnumerator SpawnMissles()
    {
        //spawning 4-8 missles with a random offset from the boss's pivot point with a delay of 0.5 sec
        int randomMissleAmount = Random.Range(4, 8);
        for (int i = 0;i < randomMissleAmount; i++)
        {
            Vector3 spawnPoint = transform.position + Random.insideUnitSphere * missleSpawnRadius;
            Instantiate(Missle, spawnPoint, transform.rotation);
            yield return new WaitForSeconds(0.5f);
        }

    }
}
