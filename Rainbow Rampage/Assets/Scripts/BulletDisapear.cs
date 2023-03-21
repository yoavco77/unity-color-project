using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDisapear : MonoBehaviour
{
    private float timer;
    public float bulletRange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    void Update()
    {
        timer += Time.deltaTime * 3;
        
        if(timer > bulletRange)
        {
            Destroy(gameObject);
            timer= 0;
        }
    }
}
