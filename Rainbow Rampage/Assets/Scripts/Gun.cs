using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform spawner;
    public PlayerColorHandler colorHandler;
    private SpriteRenderer spriteRenderer;
    public float bulletSpeed;
    public GameObject bulletPrefab;
    public float cooldown;
    private bool canFire = true;
    public int bulletDamage;
    public float bulletRange;


    void Update()
    {
      
       

        //looking for input and shooting
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && canFire == true)
        {
            shoot();
            StartCoroutine(cooldownWait());

        }



    }
    

    
    //shoot func
    void shoot()
    {
        canFire = false;
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(spawner.position.x, spawner.position.y, 1), spawner.rotation);
        if (bullet != null )
        {
        bullet.GetComponent<SpriteRenderer>().color = colorHandler.getColor();

        }
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(spawner.right * bulletSpeed, ForceMode2D.Impulse);
        StartCoroutine(bulletDespawn(bullet));


    }

   
    IEnumerator cooldownWait()
    {
        yield return new WaitForSeconds(cooldown);
        canFire = true;
    }

    IEnumerator bulletDespawn(GameObject bullet)
    {
        yield return new WaitForSeconds(bulletRange);
        Destroy(bullet);
    }
}
