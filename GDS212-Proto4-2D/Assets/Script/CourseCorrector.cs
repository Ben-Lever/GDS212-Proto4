using Fungus;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CourseCorrector : MonoBehaviour
{
    private Rigidbody2D rb;
    public HingeJoint2D hinge;
    public float correctionSpeed;
    public float angle;
    public JointMotor2D jointMotor;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jointMotor = GetComponent<JointMotor2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //AngleCorrector();
    }

    //Get the hinge angle and add torque based on that opposite to the angle
            //void AngleCorrector()
            //{

            //    //limits the angle
            //    angle = hinge.jointAngle;
            //    if (angle > 5)
            //    {
            //        angle = 5;
            //    }
            //    else if (angle < -5) { 
            //        angle = -5; 
            //    }

            //    //assign motor speed to class cos apparently needed
            //    jointMotor.motorSpeed = -angle * correctionSpeed; 

            //    hinge.motor = jointMotor;


            //}
}
