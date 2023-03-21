using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDisapear : MonoBehaviour
{
    private float timer;
    public float bulletRange;
    public int BulletDamage;
    private EnemyLogic logic;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            logic = collision.gameObject.GetComponent<EnemyLogic>();
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
