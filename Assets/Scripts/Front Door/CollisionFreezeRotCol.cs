using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFreezeRotCol : MonoBehaviour
{
    Rigidbody m_Rigidbody;

    //Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision Detected with " + other.gameObject.name + " with tag " + other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Player Tag Check Passed.  Freezing Position and Rotation");
            //Freeze Position and Rotation
            m_Rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
    }

    void OnTriggerExit(Collider other)
    {
        //Debug.Log("Collision Detected with " + other.gameObject.name + " with tag " + other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Player Tag Check Passed.  Freezing Position and Rotation");
            //Unfreeze Position and Rotation
            m_Rigidbody.constraints = RigidbodyConstraints.None;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        //Debug.Log("Collision Detected with " + other.gameObject.name + " with tag " + other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Player Tag Check Passed.  Freezing Position and Rotation");
            //Freeze Position and Rotation
            m_Rigidbody.constraints = RigidbodyConstraints.FreezePosition | RigidbodyConstraints.FreezeRotation;
        }
    }

    void OnCollisionExit(Collision other)
    {
        //Debug.Log("Collision Detected with " + other.gameObject.name + " with tag " + other.gameObject.tag);
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("Player Tag Check Passed.  Freezing Position and Rotation");
            //Unfreeze Position and Rotation
            m_Rigidbody.constraints = RigidbodyConstraints.None;
        }
    }
}