using System.Collections;
using UnityEngine;

public class CollisionBreakLaptop : MonoBehaviour
{
    AudioSource audioSource;
    public GameObject brokenLaptopScreen;
    public bool isBroken = false;
    [SerializeField] int counter;
    public Material brokenLaptopScreenOff;
    private PlayRickRollVideo _playRickRollVideo;

    //Start is called before the first frame update
    void Start()
    {
        counter = 0;
        _playRickRollVideo = GameObject.Find("Laptop_Screen").GetComponent<PlayRickRollVideo>();
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("CollisionBreakLaptop - Collision Detected with " + other.gameObject.name + " with tag " + other.gameObject.tag);

        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Wall" || other.gameObject.tag == "Dart" || other.gameObject.tag == "Sword")
        {
            //Debug.Log("CollisionBreakLaptop - Hand Tag Check for OnTriggerEnter Passed.  Calling PlayRickRollVideo's Play() Method");

            //Set the brokenLaptopScreen Game Object to Active
            brokenLaptopScreen.SetActive(true);

            //Get Audio Souce Component
            audioSource = GameObject.Find("Broken_Laptop_Screen").GetComponent<AudioSource>();

            //Play Audio
            audioSource.Play();

            //Run CoRoutine to Wait One Second
            StartCoroutine(WaitForOneSecond());

            //Play Video
            //PlayRickRollVideo.Stop();

            //Increment the counter by one
            counter++;

            if (_playRickRollVideo.VideoIsPlaying == true)
            {
                if (counter > 8)
                {
                    Renderer renderer = GameObject.Find("Broken_Laptop_Screen").GetComponent<Renderer>();
                    renderer.material = brokenLaptopScreenOff;

                    //Stop Video
                    _playRickRollVideo.videoPlayer.Stop();

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
    }

    IEnumerator WaitForOneSecond()
    {
        yield return new WaitForSeconds(1);
        //Debug.Log("1 Second has passed");
    }
}