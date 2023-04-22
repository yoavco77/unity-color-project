using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnMissles : MonoBehaviour
{
    public GameObject Missle;
    public float wait;
    public float howMuchWait;

    public bool Finished = false;

    void Start()
    {
        wait = howMuchWait;
    }
    IEnumerator spawnMissles(GameObject _missle)
    {
        //spawning 4-8 missles with a random offset from the boss's pivot point with a delay of 0.5 sec
        int missleCount = 6;
        for (int i = 0; i < missleCount; i++)
        {
            Vector3 spawnPoint = transform.position;
            GameObject Missle = Instantiate(_missle, spawnPoint, transform.rotation);
            Missle.GetComponent<EnemyFollow>().enabled = false;
            Missle.GetComponent<Rigidbody2D>().gravityScale = 1f;

            yield return new WaitForSeconds(Random.Range(0.5f, 1f));
            Missle.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Missle.GetComponent<Rigidbody2D>().gravityScale = 0;
            Missle.GetComponent<EnemyFollow>().enabled = true;
            yield return new WaitForSeconds(0.5f);
        }

        Finished = true;

    }

    public void missleAttack()
    {
        StartCoroutine(spawnMissles(Missle));

        while (!Finished)
        {

        }
        gameObject.GetComponent<Animator>().SetTrigger("Attacked");

    }

    public void portalClose()
    {
        for (int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; i++)
        {
            GameObject.FindGameObjectsWithTag("Enemy")[i].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GameObject.FindGameObjectsWithTag("Enemy")[i].GetComponent<Rigidbody2D>().gravityScale = 0;
            GameObject.FindGameObjectsWithTag("Enemy")[i].GetComponent<EnemyFollow>().enabled = true;
        }

        Destroy(gameObject);
    }
}
