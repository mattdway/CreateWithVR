using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WateringCanDropUpright : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        //Debug.Log("Collision Detected with " + other.gameObject.name + " with tag " + other.gameObject.tag);
        if (other.gameObject.tag == "Floor" | other.gameObject.tag == "Floor" | other.gameObject.tag == "Furniture" | other.gameObject.tag == "Untagged")
        {
            //Debug.Log("Rotating Game Object");
            float currentY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(0, currentY, 0);
        }
    }
}