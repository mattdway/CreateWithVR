using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecordHandleMove : MonoBehaviour
{
    public bool songOver = false;

    // Start is called before the first frame update
    void Start()
    {
        // Start the coroutine to rotate the object to the desired end rotation
        StartCoroutine(RotateObject(new Vector3(0, 68.0f, 0), 300));
    }

    // Define the coroutine to rotate the object
    IEnumerator RotateObject(Vector3 angles, float duration)
    {
        // Define the starting rotation of the object
        Quaternion startRotation = transform.rotation;

        // Define the end rotation of the object based on the input angles and starting rotation
        Quaternion endRotation = Quaternion.Euler(angles) * startRotation;

        // Loop over the duration of the rotation
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            // Calculate the current rotation based on the elapsed time and duration
            float tNormalized = t / duration;
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, tNormalized);

            // Set the variable currentYRotation equal to the transform rotation of eulerAngles.y
            float currentYRotation = transform.rotation.eulerAngles.y;
          
            //Debug.Log("currentRotation = " + currentYRotation);

            // Exit the loop if the exit condition is met
            if (currentYRotation > 340.50f)
            {
                break;
            }

            // Wait for the next frame
            yield return null;
        }

        // Set the Y rotation of the game object to 52.026 degrees
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y - 25.761f, transform.eulerAngles.z);

        // Set the public variable songOver to true
        songOver = true;
    }
}