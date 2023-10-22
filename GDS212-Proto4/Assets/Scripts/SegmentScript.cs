using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegmentScript : MonoBehaviour
{
    public GameObject leftLegs;
    public GameObject rightLegs;
    public string thisObject;

    // Start is called before the first frame update
    void Start()
    {
        thisObject = gameObject.name;
        //FindLegs();
    }

    // Update is called once per frame
    void Update()
    {
        bool leftMoving;
        bool rightMoving;

        if (leftLegs.GetComponent<LegMovement>().moveSpeed == 0)
        {
            leftMoving = false;
        }
        else
        {
            leftMoving = true;
        }
        if (rightLegs.GetComponent<LegMovement>().moveSpeed == 0)
        {
            rightMoving = false;
        }
        else
        {
            rightMoving = true;
        }

        /*
        if (!leftMoving && rightMoving)
        {
            // Rotate the capsule (e.g., turn left)
            transform.Rotate(Vector3.up, -Time.deltaTime * 10);
        }
        else if (leftMoving && !rightMoving)
        {
            // Rotate the capsule (e.g., turn right)
            transform.Rotate(Vector3.up, Time.deltaTime * 10);
        }
        */
    }

    /*
    public void FindLegs()
    {
        switch (thisObject)
        {
            case "FrontBody":
                leftLegs = transform.Find("FrontLeftLegs").gameObject;
                rightLegs = transform.Find("FrontRightLegs").gameObject;
                break;

            case "MiddleBody":
                leftLegs = transform.Find("MiddleLeftLegs").gameObject;
                rightLegs = transform.Find("MiddleRightLegs").gameObject;
                break;

            case "BackBody":
                leftLegs = transform.Find("BackLeftLegs").gameObject;
                rightLegs = transform.Find("BackRightLegs").gameObject;
                break;

            default:
                Debug.Log("Leg objects not found");
                break;
        }
    }
    */
}
