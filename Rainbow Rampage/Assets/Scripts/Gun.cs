using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform spawner;
    public float bulletSpeed;
    public GameObject bulletPrefab;
    public float cooldown;
    private float cooldownTimer;
    private bool canFire = true;
    public int bulletDamage;
    private float timer;
    public float bulletRange;


    void Update()
    {
        timer += Time.deltaTime * 3;
        //making a cooldwon on the gun
        cooldownTimer += Time.deltaTime * 3;
        if (cooldownTimer > cooldown)
        {
            canFire = true;
            cooldownTimer = 0;
        }

        //looking for input and shooting
        if (Input.GetKeyDown(KeyCode.Space) && canFire)
        {

            shoot();

        }



    }
    

    
    //shoot func
    void shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, new Vector3(spawner.position.x, spawner.position.y, 1), spawner.rotation);
        canFire = false;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(spawner.right * bulletSpeed, ForceMode2D.Impulse);
        
        if (timer > bulletRange)
        {
            Destroy(bullet);
            timer = 0;
        }


    }

}
