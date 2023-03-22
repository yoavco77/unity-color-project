using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class WaveSystem : MonoBehaviour
{
    public enum SpawnState { Spawning, Fighting, Counting};
    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform enemy;
        public int enemyCount;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;
    public float timeInBetween = 5f;
    public float waveCountdown;

    private float checkCountdown = 1f;

    private SpawnState state = SpawnState.Counting;
    void Start()
    {
        waveCountdown = timeInBetween;

    }

    void Update()
    {
        if (state == SpawnState.Fighting)
        {
            if (!IsEnemyAlive())
            {
                return;
            }
            else
            {
                return;
            }
        }


        if (waveCountdown <= 0)
        {
            if (state != SpawnState.Spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }

    }

    bool IsEnemyAlive()
    {
        checkCountdown -= Time.deltaTime;
        
        if(checkCountdown <= 0f)
        {
            checkCountdown = 1f;
            if(GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                waveCountdown = timeInBetween;
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        state = SpawnState.Spawning;

        for (int i = 0; i < _wave.enemyCount; i++)
        {
            SpawnEnemy(_wave.enemy);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.Fighting;

        nextWave++;

        if (nextWave >= waves.Length)
        {
            nextWave = 0;
        }

        waveCountdown = timeInBetween;

        yield break;


    }


    void SpawnEnemy(Transform _enemy)
    {
        Instantiate(_enemy, transform.position, transform.rotation);
    }

}
