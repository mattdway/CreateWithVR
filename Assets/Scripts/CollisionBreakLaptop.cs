using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBreakLaptop : MonoBehaviour
{
    PlayVideo playVideoScript;
    AudioSource audioSource;
    public GameObject brokenLaptopScreen;
    public bool isBroken = false;
    [SerializeField] int counter;
    public Material brokenLaptopScreenOff;

    //Start is called before the first frame update
    void Start()
    {
        counter = 0;
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("CollisionBreakLaptop - Collision Detected with " + other.gameObject.name + " with tag " + other.gameObject.tag);

        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Wall")
        {
            //Debug.Log("CollisionBreakLaptop - Hand Tag Check for OnTriggerEnter Passed.  Calling playVideoScript's Play() Method");

            //Set the brokenLaptopScreen Game Object to Active
            brokenLaptopScreen.SetActive(true);

            //Get Audio Souce Component
            audioSource = GameObject.Find("Broken_Laptop_Screen").GetComponent<AudioSource>();

            //Play Audio
            audioSource.Play();

            //Run CoRoutine to Wait One Second
            StartCoroutine(WaitForOneSecond());

            //Get Play Video Component
            playVideoScript = GameObject.Find("Laptop_Screen").GetComponent<PlayVideo>();

            //Play Video
            playVideoScript.Stop();

            //Increment the counter by one
            counter++;

            if(counter > 4)
            {
                Renderer renderer = GameObject.Find("Broken_Laptop_Screen").GetComponent<Renderer>();
                renderer.material = brokenLaptopScreenOff;

                //Set the isBroken Bool to true
                isBroken = true;
            }
            else
            {
                //Set the isBroken Bool to false
                isBroken = false;
            }
        }
    }

    IEnumerator WaitForOneSecond()
    {
        yield return new WaitForSeconds(1);
        //Debug.Log("1 Second has passed");
    }
}