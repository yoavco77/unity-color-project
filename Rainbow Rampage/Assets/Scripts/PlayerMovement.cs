using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    private Vector2 axis;
    public SpriteRenderer sp;

    void start()
    {
        sp = GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        axis.x = Input.GetAxisRaw("Horizontal");
        axis.y = Input.GetAxisRaw("Vertical");

        if (axis.x > 0)
        {
            sp.flipX = false;
        }
        else if (axis.x < 0)
        {
            sp.flipX = true;
        }
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + axis.x * movementSpeed * Time.deltaTime,transform.position.y + axis.y *movementSpeed* Time.deltaTime,transform.position.z);
    }
}
