using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Linq;

// Creating Dart_Game_Activation class that inherits from MonoBehaviour
public class Dart_Game_Activation : MonoBehaviour
{
    // Private variable for _gameManager
    private GameManager _gameManager;

    // Public variables for Launch_Dart_With_Count, AudioSource, and GameObjects for DartGameScore, DartGameColliders and the public book DartGameStarted
    public AudioSource AudioSource;
    public GameObject DartGameScore;
    public XRDirectInteractor LeftHandController;
    public XRDirectInteractor RightHandController;
    public bool DartGameStarted = false;
    private GameObject _dartGun;

    // Start is called before the first frame update
    void Start()
    {
        // Find the game object "GameManager" and get the component GameManager to assign it to _gameManager
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // Get AudioSource component from this object
        AudioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Print a debug message
        // Debug.Log("Dart_Game_Activation OnTriggerEntered");

        // If the collider has a "Player" tag
        if (other.gameObject.CompareTag("Player"))
        {
            // Check to see if the player is holding the dart gun in the right hand and then get the DartGun object from the player's right hand
            if (RightHandController.interactablesSelected.FirstOrDefault(x => x is MonoBehaviour && ((MonoBehaviour)x).gameObject.CompareTag("Dart Gun")) != null)
            {
                // Print a debug message
                // Debug.Log("Inside if statement for right hand dart gun");

                // If the player is holding the dart gun in their right hand then add this to the _dartGun variable
                _dartGun = ((MonoBehaviour)RightHandController.interactablesSelected.FirstOrDefault(x => x is MonoBehaviour && ((MonoBehaviour)x).gameObject.CompareTag("Dart Gun"))).gameObject;

                // Print a debug message
                // Debug.Log("_dartGun = " + _dartGun);
            }

            // Get the DartGun object from the player left hand
            else if (LeftHandController.interactablesSelected.FirstOrDefault(x => x is MonoBehaviour && ((MonoBehaviour)x).gameObject.CompareTag("Dart Gun")) != null)
            {
                // Print a debug message
                // Debug.Log("Inside if statement for left hand dart gun");

                // If the player is holding the dart gun in their left hand then add this to the _dartGun variable
                _dartGun = ((MonoBehaviour)LeftHandController.interactablesSelected.FirstOrDefault(x => x is MonoBehaviour && ((MonoBehaviour)x).gameObject.CompareTag("Dart Gun"))).gameObject;

                // Print a debug message
                // Debug.Log("_dartGun = " + _dartGun);
            }

            // Print a debug message
            //Debug.Log("_dartGun = " + _dartGun);

            // If the player has a DartGun
            if (_dartGun != null && _dartGun.CompareTag("Dart Gun"))
            {
                // Print a debug message 
                // Debug.Log("Dart_Game_Activation collided with " + other.gameObject.tag);

                // Set bool variable DartGameStarted = true
                DartGameStarted = true;

                // Play the audio source
                AudioSource.Play();

                // Activate DartGameScore and CountdownTimer game objects
                DartGameScore.SetActive(true);

                // Call the ResetScore method in the GameManager script
                _gameManager.ResetScore();

                // Call the IncreaseDartCount method in the GameManager script
                _gameManager.IncreaseDartCount();

                // Call the UpdateCountdownTimer() method to start the mini-game
                _gameManager.UpdateCountdownTimer();
            }
        }
    }

    // Called when a collider exits this object's trigger volume
    private void OnTriggerExit(Collider other)
    {
        // If the collider has a "Player" tag
        if (other.gameObject.tag == "Player")
        {
            // Print a debug message
            //Debug.Log("Dart_Game_Activation OnTriggerExited");

            // Set bool variable DartGameStarted = false
            DartGameStarted = false;

            // Clear the _dartGun variable
            _dartGun = null;

            // Deactivate DartGameScore object
            DartGameScore.SetActive(false);
        }
    }
}