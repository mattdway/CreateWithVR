using UnityEngine;
using TMPro;

public class DigitalTimeDisplay : MonoBehaviour
{
    private TextMeshProUGUI textMesh;

    private void Awake()
    {
        // Get the TextMeshProUGUI component
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        // Call the UpdateTime() method initially to display the current time
        UpdateTime();

        // Invoke the UpdateTime() method every second (adjust the interval as needed)
        InvokeRepeating("UpdateTime", 1f, 1f);
    }

    private void UpdateTime()
    {
        // Get the current system time
        System.DateTime now = System.DateTime.Now;

        // Convert the current time to 12-hour format
        string currentTime = now.ToString("h:mm:ss tt");

        // Update the TextMeshProUGUI text
        textMesh.text = currentTime;
    }
}