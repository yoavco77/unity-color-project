using System.Collections;
using System.Collections.Generic;
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

    IEnumerator startSpawn()
    {
        SpawnEnemy(colorBlob);
        yield return new WaitForSeconds(spawnRate);
        canSpawn = true;
        
    }
    void SpawnEnemy(GameObject colorBlob)
    {
        Vector3 randomPos = new Vector3();
        do
        {
            randomPos = new Vector3(Random.Range(topLeft.x, bottomRight.x), Random.Range(bottomRight.y, topLeft.y), 1);
        } while (Vector3.Distance(randomPos, player.transform.position) <= safeZoneRadius);
        GameObject blob = Instantiate(colorBlob, randomPos, transform.rotation);
        blob.GetComponent<SpriteRenderer>().color = randomColor();

    }

    Color randomColor()
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
