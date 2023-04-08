using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLogic : MonoBehaviour
{
    public GameObject Missle;

    public float attackCountdown;
    public float attackRate;
    public float stopTime;


    public float missleSpawnRadius = 3f;

    //Points
    public GameObject point1;
    public GameObject point2;
    public GameObject point3;
    public GameObject point4;
    int currentPoint = 1;

    public bool isMoving = false;

    void Start()
    {
        attackCountdown = attackRate;
    }

    void Update()
    {
        //attackCountdown -= Time.deltaTime;

        /* if (attackCountdown <= 0)
         {
             spawnMissles();
             attackCountdown = attackRate;
         }*/

        if (!isMoving)
        {
            StartCoroutine(startMoving());
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

    void movement()
    {
        if (currentPoint > 4)
        {
            currentPoint = 1;
        }

        if (currentPoint == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, point2.transform.position, 1f);
        }
        else if (currentPoint == 2)
        {
            transform.position = Vector2.MoveTowards(transform.position, point3.transform.position, 1f);
        }
        else if (currentPoint == 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, point4.transform.position, 1f);
        }
        else if (currentPoint == 4)
        {
            transform.position = Vector2.MoveTowards(transform.position, point1.transform.position, 1f);
        }

        if (Vector2.Distance(transform.position, GetTargetPosition()) < 0.1f)
        {
            isMoving = false;
            currentPoint++;
        }
    }

    IEnumerator startMoving()
    {
        isMoving = true;
        movement();
        yield return new WaitForSeconds(stopTime);
    }

    Vector2 GetTargetPosition()
    {
        if (currentPoint == 1)
        {
            return point2.transform.position;
        }
        else if (currentPoint == 2)
        {
            return point3.transform.position;
        }
        else if (currentPoint == 3)
        {
            return point4.transform.position;
        }
        else if (currentPoint == 4)
        {
            return point1.transform.position;
        }
        else
        {
            return transform.position;
        }
    }
}
