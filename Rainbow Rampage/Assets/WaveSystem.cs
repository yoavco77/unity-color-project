using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.VFX;

public class WaveSystem : MonoBehaviour
{
    public enum SpawnState { Spawning, Fighting, Counting};
    
    [System.Serializable]
    
    public class Wave //wave class to create waves thrgouh inspector
    {
        public string name;
        public GameObject enemy;
        public int enemyCount;
        public float rate;
    }
    
    public Wave[] waves;//making sure we have timers and shit
    private int nextWave = 0;
    public float timeInBetween = 5f;
    public float waveCountdown;
    private float checkCountdown = 1f;

    public GameObject player;//all player and cam related var
    public Camera mainCam;
    public Vector3 topLeft;
    public Vector3 bottomRight;


    public float safeZoneRadius;
    private SpawnState state = SpawnState.Counting;
    void Start()
    {
        waveCountdown = timeInBetween;

    }

    void Update()
    {
        //updating in case of camera follow
        topLeft = mainCam.ViewportToWorldPoint(new Vector3(0, 1, mainCam.nearClipPlane));
        bottomRight = mainCam.ViewportToWorldPoint(new Vector3(1, 0, mainCam.nearClipPlane));

        //waiting for the current wave to end
        if (state == SpawnState.Fighting)
        {
            if (!IsEnemyAlive())
            {
                state = SpawnState.Counting;
                return;
            }
            else
            {
                return;
            }
        }

        //waiting for countdown to end and starting next wave
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

    bool IsEnemyAlive() //looping through all game objects once a sec to look for enemys 
    {
        checkCountdown -= Time.deltaTime;
        
        if(checkCountdown <= 0f)
        {
            checkCountdown = 1f;
            if(GameObject.FindGameObjectWithTag("Enemy") == null)
            {
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


    void SpawnEnemy(GameObject _enemy)
    {
        Vector3 randomPos = new Vector3();
        //making random positions until it is not in the safe zone
        do
        {
            randomPos = new Vector3(Random.Range(topLeft.x, bottomRight.x), Random.Range(bottomRight.y, topLeft.y), 1);
        } while (Vector3.Distance(randomPos, player.transform.position) <= safeZoneRadius);
        Instantiate(_enemy, randomPos, transform.rotation);

    }

    private void OnDrawGizmos()// look i got Gizmos to work
    {
        if (player == null) return;
        Gizmos.DrawWireSphere(player.transform.position, safeZoneRadius);
    }
    //fuck you i hate commenting
}  


