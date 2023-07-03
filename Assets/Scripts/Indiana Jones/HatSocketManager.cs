using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HatSocketManager : MonoBehaviour
{
    public string indianaJonesTag = "Indiana Jones";
    public XRSocketInteractor socketInteractor;
    public GameObject indianaJonesShadowObject;
    public GameObject indianaJonesHatObject;

    private void Awake()
    {
        // Subscribe to the select entered event of the XR Socket Interactor
        socketInteractor.selectEntered.AddListener(OnSelectEntered);
    }

    private void OnDestroy()
    {
        // Unsubscribe from the select entered event when the script is destroyed
        socketInteractor.selectEntered.RemoveListener(OnSelectEntered);
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        GameObject hatObject = args.interactable.gameObject;

        // Check if the hat object has the desired tag
        if (hatObject.CompareTag(indianaJonesTag))
        {
            // Trigger the events for Indiana Jones hat
            if (hatObject == indianaJonesHatObject)
            {
                // Enable the Indiana Jones shadow object
                EnableDisableObject enableDisableObject = indianaJonesShadowObject.GetComponent<EnableDisableObject>();
                if (enableDisableObject != null)
                {
                    enableDisableObject.EnableObject();
                }

                // Play the audio for the Indiana Jones hat
                AudioSource audioSource = hatObject.GetComponent<AudioSource>();
                if (audioSource != null)
                {
                    audioSource.Play();
                }
            }
        }
    }
}