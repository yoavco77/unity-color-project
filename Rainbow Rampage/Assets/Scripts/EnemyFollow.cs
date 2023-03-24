using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public string Playername;
    public Rigidbody2D rb;
    public float chargeAttack=4;
    public float followSpeed;
    public GameObject target;
    public float minDistance;
    // Update is called once per frame

    private void Start()
    {
        // Defining the target gameobject
        target = GameObject.Find(Playername);
        // Defining the Rigidbody2D component
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        /*
         Calculates the angle of the target
         and rotating accordingly
         */
        if(target == null)
        {
            return;
        }
            Vector3 direction = target.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));


        // Moving towards the player
        transform.position = Vector2.MoveTowards(transform.position,target.transform.position,followSpeed * Time.deltaTime);
        
        
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    
}
