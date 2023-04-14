using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject Missle;
    IEnumerator SpawnMissles()
    {
        //spawning 4-8 missles with a random offset from the boss's pivot point with a delay of 0.5 sec
        int randomMissleAmount = Random.Range(4, 8);
        for (int i = 0; i < randomMissleAmount; i++)
        {
            Vector3 spawnPoint = transform.position;
            Instantiate(Missle, spawnPoint, transform.rotation);
            Missle.GetComponent<Rigidbody2D>().gravityScale = 1;
            yield return new WaitForSeconds(Random.Range(0.5f,1f));
            Missle.GetComponent<Rigidbody2D>().gravityScale = 0;
            yield return new WaitForSeconds(0.5f);
        }

    }

    public void missleAttack()
    {
        StartCoroutine(SpawnMissles());
    }
}
