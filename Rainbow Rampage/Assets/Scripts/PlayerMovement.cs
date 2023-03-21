using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    private Vector2 axis;

    // Update is called once per frame
    void Update()
    {
        axis.x = Input.GetAxisRaw("Horizontal");
        axis.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + axis.x * movementSpeed * Time.deltaTime,transform.position.y + axis.y *movementSpeed* Time.deltaTime,transform.position.z);
    }
}
