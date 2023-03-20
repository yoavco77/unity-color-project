using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform spawner;
    public GameObject bullet;
    public float cooldown;
    private float timer;
    private bool canFire = true;
    void Update()
    {
        timer += Time.deltaTime * 3;
        
        if (timer > cooldown )
        {
            canFire = true;
            timer = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && canFire)
        {
            Instantiate(bullet, spawner.position, spawner.rotation);
            canFire = false;
        }
        

        
    }
}
