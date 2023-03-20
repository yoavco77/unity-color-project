using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    private float timer;
    public float bulletSpeed;
    public float bulletTime;
    public float timeScale = 1f;

    void Update()
    {

        transform.position = new Vector3(transform.position.x + bulletSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        timer += Time.deltaTime * timeScale;
        
        if (timer > bulletTime)
        {
            Destroy(gameObject);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
