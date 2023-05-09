using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLaptopOn : MonoBehaviour
{
    PlayVideo playVideoScript;
    AudioSource audioSource;
    private CollisionBreakLaptop _isBroken;

    //Start is called before the first frame update
    void Start()
    {
        playVideoScript = GameObject.Find("Laptop_Screen").GetComponent<PlayVideo>();
        audioSource = GameObject.Find("On Switch").GetComponent<AudioSource>();
        _isBroken = GameObject.Find("Laptop_Black_Off").GetComponent<CollisionBreakLaptop>();
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("CollisionLaptopOn - Collision Detected with " + other.gameObject.name + " with tag " + other.gameObject.tag);
        //Debug.Log("_isBroken.isBroken = " + _isBroken.isBroken);

        if (other.gameObject.tag == "Hand")
        {
            if (_isBroken.isBroken != true)
            {
                //Debug.Log("CollisionLaptopOn - Hand Tag Check for OnTriggerEnter Passed.  Calling playVideoScript's Play() Method");

                //Play Audio
                audioSource.Play();

                //Play Video
                playVideoScript.Play();

                //Exit method
                return;
            }
        }
    }
}