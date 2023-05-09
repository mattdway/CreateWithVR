using OculusSampleFramework;
using System.Collections;
using UnityEngine;

public class TransportZeldaCave : MonoBehaviour
{
    public GameObject Cave;
    public AudioSource PickUpSound;
    private bool _firstTimePickedUp = false;

    // Start is called before the first frame update
    void Start()
    {
        PickUpSound = GetComponent<AudioSource>();
    }

    private void LinksWoodenSword()
    {
        if (_firstTimePickedUp == false)
        {
            // Activate the Cave game object
            Cave.SetActive(true);

            // Play Legend of Zelda pickup sound
            PickUpSound.Play();

            StartCoroutine(ActivateCave(transform)); // Pass transform as the parent

            // Set bool variable _firstTimePickedUp to true
            _firstTimePickedUp = true;
        }
    }

    private void ChangeLayers(Transform parent, string Interactable)
    {
        parent.gameObject.layer = LayerMask.NameToLayer(Interactable);
        foreach (Transform child in parent)
        {
            ChangeLayers(child, Interactable);
        }
    }
    private IEnumerator ActivateCave(Transform parent)
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(3f);

        // Deactivate the Cave game object
        Cave.SetActive(false);

       // Change the layer of all child objects of the parent object to "Interactable"
       ChangeLayers(transform, "Interactable");
    }
}