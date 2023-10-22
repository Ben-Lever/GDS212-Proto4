using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMovement : MonoBehaviour
{
    private KeyCode makeyInput;
    public float moveSpeed = 3f;
    private string thisObject;
    private Rigidbody2D rb;
    private SpriteRenderer rend;

    public Color stoppedColor = Color.red;
    public Color movingColor = Color.green;

    // Start is called before the first frame update
    void Start()
    {
        thisObject = gameObject.name;
        rb = GetComponent<Rigidbody2D>();
        rend = GetComponent<SpriteRenderer>();
        FindMakeyInput();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the forward vector based on the object's rotation
        Vector2 forwardVector = transform.up;

        // Move the object forward using Rigidbody2D and the calculated forward vector
        rb.velocity = forwardVector * moveSpeed;



        if (Input.GetKey(makeyInput))
        {
            moveSpeed = 0f;
            rend.color = stoppedColor;
            Debug.Log("Input '" + makeyInput + "' pressed, " + thisObject + " stopped");
        }
        else
        {
            moveSpeed = 3f;
            rend.color = movingColor;
        }
        if (Input.GetKeyUp(makeyInput))
        {
            moveSpeed = 3f;
            rend.color = movingColor;
        }
    }

    public void FindMakeyInput()
    {
        switch (thisObject)
        {
            case "FrontLeftLegs":
                makeyInput = KeyCode.W;
                Debug.Log(thisObject + " assigned to input: " + makeyInput);
                break;

            case "FrontRightLegs":
                makeyInput = KeyCode.A;
                Debug.Log(thisObject + " assigned to input: " + makeyInput);
                break;

            case "MiddleLeftLegs":
                makeyInput = KeyCode.S;
                Debug.Log(thisObject + " assigned to input: " + makeyInput);
                break;

            case "MiddleRightLegs":
                makeyInput = KeyCode.D;
                Debug.Log(thisObject + " assigned to input: " + makeyInput);
                break;

            case "BackLeftLegs":
                makeyInput = KeyCode.F;
                Debug.Log(thisObject + " assigned to input: " + makeyInput);
                break;

            case "BackRightLegs":
                makeyInput = KeyCode.G;
                Debug.Log(thisObject + " assigned to input: " + makeyInput);
                break;
            default:
                Debug.Log(thisObject + " was not assigned an input ");
                break;
        }
    }
}
