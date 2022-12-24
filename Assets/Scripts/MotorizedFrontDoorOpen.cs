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
    private Door_Open_Collision_Detection _doorOpen;

    // Start is called before the first frame update
    void Start()
    {
        //Get Public Bool doorOpen From "Door_Open_Collider.cs" Script
        _doorOpen = GameObject.Find("Door_Open_Collider").GetComponent<Door_Open_Collision_Detection>();

        //Debug.Log("_doorOpen.doorOpen is set to: " + _doorOpen.doorOpen);
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
        if (_doorOpen.doorOpen == false)
        {
            //Debug.Log("Starting the open the door routine");
            //Debug.Log("The bool _doorOpen.doorOpen is currently: " + _doorOpen.doorOpen);

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

            StartCoroutine(StopMotor());

            return;
        }

        //closed the door
        if (_doorOpen.doorOpen == true)
        {
            //Debug.Log("Starting the close the door routine");
            //Debug.Log("The bool _doorOpen.doorOpen is currently: " + _doorOpen.doorOpen);

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

            StartCoroutine(StopMotor());

            return;
        }

        IEnumerator StopMotor()
        {
            //Debug.Log("Entered Coroutine");

            //Wait for 25 seconds
            yield return new WaitForSeconds(25);

            myHingeTop.useMotor = false;
            myHingeMiddle.useMotor = false;
            myHingeBottom.useMotor = false;
            //Debug.Log("useMotors Set to False");
        }
    }
}