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
        target = GameObject.Find(Playername);
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position,target.transform.position) > minDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position,target.transform.position,followSpeed * Time.deltaTime);
        }
        else
        {
            StartCoroutine(charge());

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }

    IEnumerator charge()
    {
        yield return new WaitForSeconds(chargeAttack);
        rb.AddForce(Vector2.left * followSpeed * Time.deltaTime, ForceMode2D.Impulse);   

    }
}
