using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleControl : MonoBehaviour
{
    public GameObject leftObject;
    public GameObject rightObject;

    private Rigidbody2D rb;

    public float turningTorque = 100f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Check the movement status of the side objects
        float leftMovementSpeed = leftObject.GetComponent<LegMovement>().moveSpeed;
        float rightMovementSpeed = rightObject.GetComponent<LegMovement>().moveSpeed;

        // Apply rotation based on the movement status
        if (leftMovementSpeed == 0 && rightMovementSpeed != 0)
        {
            // Rotate the capsule (e.g., turn left)
            rb.AddTorque(turningTorque);
        }
        else if (leftMovementSpeed != 0 && rightMovementSpeed == 0)
        {
            // Rotate the capsule (e.g., turn right)
            rb.AddTorque(-turningTorque);
        }
    }
}
