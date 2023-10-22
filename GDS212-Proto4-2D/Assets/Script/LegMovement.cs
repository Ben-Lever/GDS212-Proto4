using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegMovement : MonoBehaviour
{
    private KeyCode makeyInput;
    private float moveSpeed = 1f;
    private string thisObject;

    // Start is called before the first frame update
    void Start()
    {
        thisObject = gameObject.name;
        FindMakeyInput();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);


        if (Input.GetKey(makeyInput))
        {
            moveSpeed = 0f;
            Debug.Log("Input '" + makeyInput + "' pressed, " + thisObject + " stopped");
        }
        else
        {
            moveSpeed = 1f;
        }
        if (Input.GetKeyUp(makeyInput))
        {
            moveSpeed = 1f;
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
