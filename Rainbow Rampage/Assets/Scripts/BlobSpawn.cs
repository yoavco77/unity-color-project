using System.Collections;
using System.Collections.Generic;
using UnityEditor.Profiling;
using UnityEngine;

public class BlobSpawn : MonoBehaviour
{
    public Camera mainCam;
    public float safeZoneRadius;
    public GameObject player;
    public GameObject colorBlob;
    public float spawnRate;
    bool canSpawn  = true;
    Vector3 topLeft;
    Vector3 bottomRight;


    public float minAliveTime = 8f;
    public float maxAliveTime = 15f;





    void Update()
    {
        topLeft = mainCam.ViewportToWorldPoint(new Vector3(0, 1, mainCam.nearClipPlane));
        bottomRight = mainCam.ViewportToWorldPoint(new Vector3(1, 0, mainCam.nearClipPlane));

        if(canSpawn == true)
        {
            canSpawn = false;
            StartCoroutine(startSpawn());
        }


    }

    IEnumerator startSpawn()// a loop that spawns blobs at random times
    {
        while (true)
        {
            SpawnEnemy(colorBlob);

            float spawnDelay = Random.Range(2f, 7f);
            yield return new WaitForSeconds(spawnDelay);
        }
    }
    
    IEnumerator destroyAtRandom(GameObject colorBlob,float randomAliveTime) //destroy the blob after a certain amount of time
    {
        yield return new WaitForSeconds(randomAliveTime);
        DestroyImmediate(colorBlob);
    }

    void SpawnEnemy(GameObject colorBlob)//spawn a blob
    {
        Vector3 randomPos = new Vector3();
        do
        {
            randomPos = new Vector3(Random.Range(topLeft.x, bottomRight.x), Random.Range(bottomRight.y, topLeft.y), 1);
        } while (Vector3.Distance(randomPos, player.transform.position) <= safeZoneRadius);
        GameObject blob = Instantiate(colorBlob, randomPos, transform.rotation);
        blob.GetComponent<SpriteRenderer>().color = randomColor();

        //run the IEnumerator
        float randomAliveTime = Random.Range(minAliveTime, maxAliveTime);
        StartCoroutine(destroyAtRandom(blob, randomAliveTime));

    }

    Color randomColor() //genarating a random color
    {
        int randomColor = Random.Range(0, 4);
        if (randomColor == 0)
        {
            return Color.red;
        }
        else if (randomColor == 1)
        {
            return Color.green;
        }
        else if (randomColor == 2)
        {
            return Color.cyan;
        }
        else
        {
            return Color.yellow;
        }

    }


}
