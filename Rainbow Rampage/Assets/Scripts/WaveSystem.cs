using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.VFX;

public class WaveSystem : MonoBehaviour
{
    public enum SpawnState {Spawning, Fighting, Counting};
    
    [System.Serializable]
    
    public class Wave //wave class to create waves through inspector
    {
        public string name;
        public GameObject enemy;
        public int enemyCount;
        public float rate;
        public GameObject boss;
        public GameObject bossRune;

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

    public Vector3 top;
    public Vector3 bottom;
    public Vector3 left;
    public Vector3 right;


    public float safeZoneRadius;
    private SpawnState state = SpawnState.Counting;

    public Vector3[] runePos;

    void Start()
    {
        waveCountdown = timeInBetween;

    }

    void Update()
    {
        //updating in case of camera follow
        topLeft = mainCam.ViewportToWorldPoint(new Vector3(0, 1, mainCam.nearClipPlane));
        bottomRight = mainCam.ViewportToWorldPoint(new Vector3(1, 0, mainCam.nearClipPlane));

        //updating in case of camera follow


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
            if((GameObject.FindGameObjectWithTag("Enemy") == null) && (GameObject.FindGameObjectWithTag("Boss") == null ))
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

        if (_wave.boss != null)
        {
            SpawnBoss(_wave.bossRune, _wave.boss);
        } 

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
        GameObject enemy = Instantiate(_enemy, randomPos, transform.rotation);
        enemy.GetComponent<SpriteRenderer>().color = randomColor();

    }

    private void OnDrawGizmos()// look i got Gizmos to work
    {
        if (player == null) return;
        Gizmos.DrawWireSphere(player.transform.position, safeZoneRadius);
    }

    Color randomColor()
    {
        Color pick;
        int randomColor = Random.Range(0, 4);
        if (randomColor == 0)
        {
            pick = Color.red;
        }
        else if (randomColor == 1)
        {
            pick = Color.green;
        }
        else if (randomColor == 2)
        {
            pick = Color.cyan;
        }
        else
        {
            pick = Color.yellow;
        }

        return pick;
    }
    //fuck you i hate commenting
    //I love you so much yair <3

    void SpawnBoss(GameObject _rune,GameObject _boss)
    {
        
        //making positions for the boss runes in a quarter distance from the center of the screen
        top = mainCam.ViewportToWorldPoint(new Vector3(0.5f, 0.75f, mainCam.nearClipPlane));
        bottom = mainCam.ViewportToWorldPoint(new Vector3(0.5f, 0.25f, mainCam.nearClipPlane));
        left = mainCam.ViewportToWorldPoint(new Vector3(0.25f, 0.5f, mainCam.nearClipPlane));
        right = mainCam.ViewportToWorldPoint(new Vector3(0.75f, 0.5f, mainCam.nearClipPlane));

        GameObject bossRune1 = Instantiate(_rune , top, transform.rotation);
        bossRune1.transform.localScale = new Vector3(5f, 5f, 5f);
        
        GameObject bossRune2 = Instantiate(_rune, bottom, transform.rotation);
        bossRune2.transform.localScale = new Vector3(5f, 5f, 5f);
        
        GameObject bossRune3 = Instantiate(_rune, left, transform.rotation);
        bossRune3.transform.localScale = new Vector3(5f, 5f, 5f);
        
        GameObject bossRune4 = Instantiate(_rune, right, transform.rotation);
        bossRune4.transform.localScale = new Vector3(5f, 5f, 5f);
        
        //spawning the runes and the boss and scaling them by 10.5
        GameObject boss = Instantiate(_boss, topLeft, transform.rotation);
        boss.transform.localScale = new Vector3(7.5f, 7.5f, 7.5f);

        ///
        ///

    }
}  


