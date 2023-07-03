using UnityEngine;

public class EnableDisableObject : MonoBehaviour
{
    public GameObject objectToEnableDisable;
    public float enableTime = 9f;

    private void Start()
    {
        // Disable the object on start
        objectToEnableDisable.SetActive(false);
    }

    public void EnableObject()
    {
        // Enable the object
        objectToEnableDisable.SetActive(true);

        // Call the DisableObject method after enableTime seconds
        Invoke("DisableObject", enableTime);
    }

    private void DisableObject()
    {
        // Disable the object
        objectToEnableDisable.SetActive(false);
    }
}