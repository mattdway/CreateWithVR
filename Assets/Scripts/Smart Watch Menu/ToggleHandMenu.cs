using UnityEngine;

public class ToggleHandMenu : MonoBehaviour
{
    public GameObject handMenuCanvas;
    public string targetTag = "RightHand";
    private bool isMenuActive = false;

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("ToggleHandMenu Collision Occured");

        if (collision.gameObject.CompareTag(targetTag))
        {
            // Debug.Log("ToggleHandMenu Collision Is Right Hand");
            ToggleMenu();
        }
    }

    private void ToggleMenu()
    {
        // Debug.Log("Activating Hand Menu");
        isMenuActive = !isMenuActive;
        handMenuCanvas.SetActive(isMenuActive);
    }
}