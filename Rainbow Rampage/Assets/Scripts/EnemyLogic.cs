using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public int maxHealth;
    public PlayerColorHandler colorHandler;
    public SpriteRenderer spriteRenderer;
    int currentHealth;
    public Gun gun;

    private void Start()
    {
        currentHealth = maxHealth;
        colorHandler = GameObject.Find("Player").GetComponent<PlayerColorHandler>();
    }
    
    void Update()
    {
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        {
            if (collision.gameObject.CompareTag("Bullet") && spriteRenderer.color == colorHandler.getColor()) 
            {
                Destroy(collision.gameObject);
                TakeDamge(25);
            }
        }
    }
    void Die()
    {
        this.enabled = false;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        StartCoroutine(wait());
    }
    
    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }

    public void TakeDamge(int damage)
    {
        currentHealth -= damage;
    }
}
