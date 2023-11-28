using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    

    public float moveSpeed, turnSpeed = 0.1f;



    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //Rigidbodies have to set new coordinates
        //although in code calculate the movement
        rb.MovePosition(transform.position + (transform.up * moveSpeed));

        if (Input.GetKey(KeyCode.A))
        {
            rb.MoveRotation(rb.rotation + turnSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.MoveRotation(rb.rotation - turnSpeed);
        }
    }

    
}
