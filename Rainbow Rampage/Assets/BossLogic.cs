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

            attackCountdown = attackRate;
        }
        else
        {
            attackCountdown -= Time.deltaTime;
        }


    }



}
