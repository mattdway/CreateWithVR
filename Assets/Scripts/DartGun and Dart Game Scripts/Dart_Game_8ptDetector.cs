using System.Collections;
using UnityEngine;

public class Dart_Game_8ptDetector : MonoBehaviour
{
    // Declare public variables
    public GameManager GameManager; // a reference to GameManager object
    public AudioSource AudioSource; // a reference to AudioSource object
    private bool _isAlreadyColliding;

    // Declare private variables
    private bool isStillColliding = false; // a flag indicating if the dart is colliding with the detector
    private static int _awarded = 8; // a static variable to store the awarded score

    // Start is called before the first frame update
    void Start()
    {
        // Get AudioSource component from this object
        AudioSource = GetComponent<AudioSource>();
    }

    // Called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider collision)
    {
        // Check if the other game object has a tag of "Dart"
        if (collision.gameObject.tag == "Dart")
        {
            // Set the flag to true
            isStillColliding = true;

            // Start coroutine to update the score
            StartCoroutine(UpdateScore());
        }
    }

    // Called when the Collider other has stopped touching the trigger
    private void OnTriggerExit(Collider collision)
    {
        // Check if the other game object has a tag of "Dart"
        if (collision.gameObject.tag == "Dart")
        {
            // Set the flag to false
            isStillColliding = false;

            // Set the flag to false
            _isAlreadyColliding = false;
        }
    }

    // Coroutine to update the score
    IEnumerator UpdateScore()
    {
        // Wait for 1.5 seconds
        yield return new WaitForSeconds(1.5f);

        // Check if the flag is still true
        if (isStillColliding == true)
        {
            if (_isAlreadyColliding == false)
            {
                // Set the flag to true
                _isAlreadyColliding = true;

                // Update the text of the awarded score
                GameManager.AwardedText.text = "+" + _awarded.ToString("00");

                // Play the audio source
                AudioSource.Play();

                // Wait for half a second
                yield return new WaitForSeconds(0.5f);

                // Clear the text of the awarded score
                GameManager.AwardedText.text = "";

                // Update the score value in the GameManager
                GameManager.ScoreValue += _awarded;
                GameManager.ScoreText.text = "Score:" + GameManager.ScoreValue.ToString("00");
            }
        }
    }
}