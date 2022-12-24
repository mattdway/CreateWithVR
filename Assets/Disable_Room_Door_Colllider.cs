using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable_Room_Door_Colllider : MonoBehaviour
{
    [SerializeField] private GameObject _DoorWallCollider;

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Disable_Room_Door_Collider Trigger Entered");
        if (other.gameObject.tag == "DoorHandle")
        {
            _DoorWallCollider.SetActive(false);
            //Debug.Log("DoorWallColiider Disabled");
        }
    }

    void OnTriggerExit(Collider other)
    {
        //Debug.Log("Disable_Room_Door_Collider Trigger Exited");
        if (other.gameObject.tag == "DoorHandle")
        {
            _DoorWallCollider.SetActive(true);
            //Debug.Log("DoorWallColiider Enabled");
        }
    }
}