using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    

    public float moveSpeed, turnSpeed = 0.1f;

    private int legsActive, legsTilt;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //Rigidbodies have to set new coordinates
        //although in code calculate the movement
        
        
        legsActive = 0;
        legsTilt = 0;

        if (Input.GetKey(KeyCode.Q))
        {
            legsActive++;
            legsTilt--;
        }
        if (Input.GetKey(KeyCode.W))
        {
            legsActive++;
            legsTilt++;
        }
        if (Input.GetKey(KeyCode.A))
        {
            legsActive++;
            legsTilt--;
        }
        if (Input.GetKey(KeyCode.S))
        {
            legsActive++;
            legsTilt++;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            legsActive++;
            legsTilt--;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            legsActive++;
            legsTilt++;
        }

        //negative just cos I don't wanna rewrite above stuff
        rb.MoveRotation(rb.rotation - turnSpeed * legsTilt / 10);

        rb.MovePosition(transform.position + (transform.up * moveSpeed * legsActive / 20));
    }

    
}
