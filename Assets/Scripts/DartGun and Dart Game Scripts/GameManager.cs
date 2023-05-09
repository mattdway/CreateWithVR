// Importing Unity engine and TextMeshPro package
using UnityEngine;
using TMPro;

// Create GameManager class that inherits from MonoBehaviour
public class GameManager : MonoBehaviour
{
    // Public TextMeshProUGUI variables for displaying Score and Awarded Text
    public TextMeshProUGUI ScoreText; // reference to the TextMeshProUGUI component
    public TextMeshProUGUI AwardedText; //reference to the TextMeshProUGUI component
    public TextMeshProUGUI CountdownTimer; // reference to the TextMeshProUGUI component
    public float timeLeft = 60.0f; // the total time left for the countdown
    public bool isAlreadyColliding = false;

    // Public integer variable for ScoreValue
    public int ScoreValue = 0;

    // Private variable for _launchDartWithCount
    private Launch_Dart_With_Count _launchDartWithCount;

    // Start is called before the first frame update
    void Start()
    {
        // Find the game object "Launcher_DartGun" and get the component Launch_Dart_With_Count to assign it to _launchDartWithCount
        _launchDartWithCount = GameObject.Find("Launcher_DartGun").GetComponent<Launch_Dart_With_Count>();

        // Clear the text of the awarded score
        AwardedText.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    // New public method that updates the countdown timer
    public void UpdateCountdownTimer()
    {
        // Subtract the time that has passed since the last frame from the total time left for the countdown
        timeLeft -= Time.deltaTime;
        // Calculate the number of minutes left by dividing the remaining time by 60 and rounding down to the nearest integer
        int minutes = Mathf.FloorToInt(timeLeft / 60);
        // Calculate the number of seconds left by getting the remainder of the total time left divided by 60 and rounding down to the nearest integer
        int seconds = Mathf.FloorToInt(timeLeft % 60);
        // Format the minutes and seconds as a string in the format "mm:ss" and set the TextMeshProUGUI component's text to the new time left
        CountdownTimer.text = string.Format("Countdown: {0:00}:{1:00}", minutes, seconds);
    }

    // Public method to reset score
    public void ResetScore()
    {
        // If ScoreText exists and is active in the scene
        if (ScoreText != null && ScoreText.gameObject.activeSelf)
        {
            // Set ScoreValue to 0
            ScoreValue = 0;

            // Set ScoreText to "Score:" + ScoreValue.ToString("00")
            ScoreText.text = "Score:" + ScoreValue.ToString("00");
        }
    }

    // Public method to increase the dart count
    public void IncreaseDartCount()
    {
        // Set _launchDartWithCount.DartCount to 35
        _launchDartWithCount.DartCount = 35;
    }
}