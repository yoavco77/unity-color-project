using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject Missle;
    public float wait;
    public float howMuchWait;

    void Start()
    {
        wait = howMuchWait;
    }
    IEnumerator SpawnMissles(GameObject _missle)
    {
        //spawning 4-8 missles with a random offset from the boss's pivot point with a delay of 0.5 sec
        int randomMissleAmount = Random.Range(4, 8);
        for (int i = 0; i < randomMissleAmount; i++)
        {
            Vector3 spawnPoint = transform.position;
            GameObject Missle = Instantiate(_missle, spawnPoint, transform.rotation);
            Missle.GetComponent<Rigidbody2D>().gravityScale = 0.2f;
            yield return new WaitForSeconds(Random.Range(0.02f,0.1f));
            Missle.GetComponent<Rigidbody2D>().gravityScale = 0;
            yield return new WaitForSeconds(0.5f);
        }

    }

    public void missleAttack()
    {
        StartCoroutine(SpawnMissles(Missle));
        
    }
}
