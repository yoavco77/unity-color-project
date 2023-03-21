using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public int maxHealth;
    int currentHealth;
    public Gun gun;

    private void Start()
    {
        currentHealth = maxHealth;
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
            if (collision.gameObject.CompareTag("Bullet"))
            {
                Destroy(collision.gameObject);
                TakeDamge(gun.bulletDamage);
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
