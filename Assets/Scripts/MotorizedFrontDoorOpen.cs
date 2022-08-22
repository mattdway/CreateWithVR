using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorizedFrontDoorOpen : MonoBehaviour
{
    public GameObject Door;
    public HingeJoint myHingeTop;
    public HingeJoint myHingeMiddle;
    public HingeJoint myHingeBottom;

    // Start is called before the first frame update
    void Start()
    {
        var myHingeTop = Door.GetComponent<HingeJoint>();
        var myHingeMiddle = Door.GetComponent<HingeJoint>();
        var myHingeBottom = Door.GetComponent<HingeJoint>();

        myHingeTop.useMotor = false;
        myHingeMiddle.useMotor = false;
        myHingeBottom.useMotor = false;
    }

    public void OpenDaDoor()
    {
        myHingeTop.useMotor = true;
        myHingeMiddle.useMotor = true;
        myHingeBottom.useMotor = true;

        Debug.Log("motors should be true");
    }
}