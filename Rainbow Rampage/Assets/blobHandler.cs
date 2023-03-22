using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobHandler : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public string Playername;
    public PlayerColorHandler playerColor;
    void Start()
    {

        randomColor(); 

        playerColor = GameObject.Find(Playername).GetComponent<PlayerColorHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerColor.setColor(spriteRenderer.color);
            Destroy(gameObject);
        }
    }

    void randomColor()
    {
        int randomColor = Random.Range(0, 4);
        if (randomColor == 0)
        {
            spriteRenderer.color = Color.red;
        }
        else if (randomColor == 1)
        {
            spriteRenderer.color = Color.green;
        }
        else if (randomColor == 2)
        {
            spriteRenderer.color = Color.cyan;
        }
        else
        {
            spriteRenderer.color = Color.yellow;
        }
    }
}
