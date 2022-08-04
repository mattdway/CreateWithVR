using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor_Original : MonoBehaviour
{
    public bool open;
    public float minRotation;
    public float maxRotation;
    public float openSpeed;
    private float rotationY;

    // Start is called before the first frame update
    void Start()
    {
        // Get the initial rotation of the door
        rotationY = this.transform.localEulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (open == true)
        {
            rotationY += openSpeed;     // Open the door
        }
        else
        {
            rotationY -= openSpeed;     //Close the door
        }

        // Limit how far door can open
        if (rotationY < minRotation)
            rotationY = minRotation;
        if (rotationY > maxRotation)
            rotationY = maxRotation;

        // Update door with new rotation
        this.transform.localEulerAngles =
            new Vector3(this.transform.localEulerAngles.x, rotationY, this.transform.localEulerAngles.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Only check for door being touched, if it's fully open or shut already
        if (rotationY == minRotation || rotationY == maxRotation)
        {
            // If door is touched toggle open and close door.
            if (other.tag == "hand")
                open = !open;
        }
    }
}
