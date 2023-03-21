using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLogic : MonoBehaviour
{
    public int maxHealth;
    int currentHealth;
    // Update is called once per frame


    private void Start()
    {
        currentHealth = maxHealth;
    }
    void Update()
    {
        if (currentHealth <= 0)
        {
            this.enabled = false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }

    public void hurt(int damage)
    {
        currentHealth -= damage;
    }
}
