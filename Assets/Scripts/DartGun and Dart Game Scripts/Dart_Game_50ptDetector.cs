using System.Collections;
using UnityEngine;

public class Dart_Game_50ptDetector : MonoBehaviour
{
    // Declare public variables
    public GameManager GameManager; // a reference to GameManager object
    public AudioSource AudioSource; // a reference to AudioSource object

    // Declare private variables
    private static int _awarded = 50; // a static variable to store the awarded score

    // Start is called before the first frame update
    void Start()
    {
        // Get AudioSource component from this object
        AudioSource = GetComponent<AudioSource>();
    }

    // Called when the Collider other enters the trigger
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Collision For 10ptDetector Entered");

        // Check if the other game object has a tag of "Dart"
        if (collision.gameObject.tag == "Dart")
        {
            Debug.Log("Objected Collided With Is Dart");

            // Update the text of the awarded score
            GameManager.AwardedText.text = "+" + _awarded.ToString("00");

            // Play the audio source
            AudioSource.Play();

            // Update the score value in the GameManager
            GameManager.ScoreText.text = "Score:" + GameManager.ScoreValue.ToString("00");

            // Disable the collider of the dart to prevent double scoring
            Collider otherCollider = collision.GetComponent<Collider>();
            otherCollider.enabled = false;

            // Start coroutine to update the score
            StartCoroutine(ShowPoints());

            return;
        }
    }

    // Coroutine to update the score
    IEnumerator ShowPoints()
    {
        GameManager.ScoreValue += _awarded;

        // Wait for half a second
        yield return new WaitForSeconds(0.5f);

        // Clear the text of the awarded score
        GameManager.AwardedText.text = "";
    }
}