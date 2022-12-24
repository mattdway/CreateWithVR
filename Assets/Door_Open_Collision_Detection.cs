using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open_Collision_Detection : MonoBehaviour
{
    public bool doorOpen = false;

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Disable_Room_Door_Collider Trigger Entered");
        if (other.gameObject.tag == "DoorHandle")
        {
            doorOpen = true;
            Debug.Log("We have collision! doorOpen Bool set to true");
        }
    }

    void OnTriggerExit(Collider other)
    {
        //Debug.Log("Disable_Room_Door_Collider Trigger Exited");
        if (other.gameObject.tag == "DoorHandle")
        {
            doorOpen = false;
            Debug.Log("Leaving collision! doorOpen Bool set to false");
        }
    }
}