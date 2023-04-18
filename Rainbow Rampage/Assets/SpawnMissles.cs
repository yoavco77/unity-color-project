using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMissles : MonoBehaviour
{
    public GameObject Missle;
    public float wait;
    public float howMuchWait;

    public Animator animator;

    void Start()
    {
        wait = howMuchWait;
    }
    IEnumerator spawnMissles(GameObject _missle)
    {
        //spawning 4-8 missles with a random offset from the boss's pivot point with a delay of 0.5 sec
        int randomMissleAmount = Random.Range(4, 8);
        for (int i = 0; i < randomMissleAmount; i++)
        {
            Vector3 spawnPoint = transform.position;
            GameObject Missle = Instantiate(_missle, spawnPoint, transform.rotation);
            Missle.GetComponent<EnemyFollow>().enabled = false;
            Missle.GetComponent<Rigidbody2D>().gravityScale = 1f;
            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
            Missle.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Missle.GetComponent<Rigidbody2D>().gravityScale = 0;
            Missle.GetComponent<EnemyFollow>().enabled = true;
            yield return new WaitForSeconds(0.1f);
        }

    }

    public void missleAttack()
    {
        StartCoroutine(spawnMissles(Missle));
        animator.SetTrigger("Already attacked");
    }

    public void closePortal()
    {
        GameObject[] enemySpawndByPortal = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i =0; i<enemySpawndByPortal.Length; i++)
        {
            enemySpawndByPortal[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            enemySpawndByPortal[i].GetComponent<Rigidbody2D>().gravityScale = 0;
            enemySpawndByPortal[i].GetComponent<EnemyFollow>().enabled = true;
        }
        Destroy(gameObject);

    }
}
