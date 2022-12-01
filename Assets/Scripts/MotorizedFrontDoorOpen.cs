using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorizedFrontDoorOpen : MonoBehaviour
{
    public GameObject Door;
    public HingeJoint myHingeTop;
    public HingeJoint myHingeMiddle;
    public HingeJoint myHingeBottom;
    public float rotationY;
    public float minRotation;
    public float maxRotation;
    public bool open;

    // Start is called before the first frame update
    void Start()
    {
        // Get the initial rotation of the door
        rotationY = this.transform.localEulerAngles.y;
    }

    public void OpenDaDoor()
    {
        var myHingeTop = Door.GetComponent<HingeJoint>();
        var myHingeMiddle = Door.GetComponent<HingeJoint>();
        var myHingeBottom = Door.GetComponent<HingeJoint>();

        var myHingeTopMotor = myHingeTop.motor;
        myHingeTopMotor.targetVelocity = -200;
        myHingeTopMotor.force = 100;

        var myHingeMiddleMotor = myHingeMiddle.motor;
        myHingeMiddleMotor.targetVelocity = -200;
        myHingeMiddleMotor.force = 100;

        var myHingeBottomMotor = myHingeBottom.motor;
        myHingeBottomMotor.targetVelocity = -200;
        myHingeBottomMotor.force = 100;

        myHingeTop.useMotor = false;
        myHingeMiddle.useMotor = false;
        myHingeBottom.useMotor = false;

        //open the door
        if (open == false)
        {
            Debug.Log("Starting the open the door routine");
            Debug.Log("The bool open is currently: " + open);

            myHingeTopMotor.targetVelocity = -200;
            myHingeTopMotor.force = 100;

            myHingeMiddleMotor.targetVelocity = -200;
            myHingeMiddleMotor.force = 100;

            myHingeBottomMotor.targetVelocity = -200;
            myHingeBottomMotor.force = 100;

            myHingeTop.motor = myHingeTopMotor;
            myHingeMiddle.motor = myHingeMiddleMotor;
            myHingeBottom.motor = myHingeBottomMotor;

            myHingeTop.useMotor = true;
            myHingeMiddle.useMotor = true;
            myHingeBottom.useMotor = true;

            open = !open;
            Debug.Log("The bool open has been changed to: " + open);
            Debug.Log("Ending the open the door routine");
            return;
        }

        //closed the door
        if (open == true)
        {
            Debug.Log("Starting the close the door routine");
            Debug.Log("The bool open is currently: " + open);

            myHingeTopMotor.targetVelocity = 200;
            myHingeTopMotor.force = 100;

            myHingeMiddleMotor.targetVelocity = 200;
            myHingeMiddleMotor.force = 100;

            myHingeBottomMotor.targetVelocity = 200;
            myHingeBottomMotor.force = 100;

            myHingeTop.motor = myHingeTopMotor;
            myHingeMiddle.motor = myHingeMiddleMotor;
            myHingeBottom.motor = myHingeBottomMotor;

            myHingeTop.useMotor = true;
            myHingeMiddle.useMotor = true;
            myHingeBottom.useMotor = true;

            open = !open;
            Debug.Log("The bool open has been changed to: " + open);
            Debug.Log("Ending the close the door routine");
            return;
        }
    }
}