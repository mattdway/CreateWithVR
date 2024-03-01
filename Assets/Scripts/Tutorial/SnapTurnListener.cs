using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.Events;
using UnityEngine.UI;

public class SnapTurnListener : MonoBehaviour
{
    private InputAction thumbstickAction; // The InputAction object for detecting thumbstick input
    private UnityEngine.XR.InputDevice rightHandDevice; // The right hand XR input device

    public UnityEvent onThumbstickRight; // Event invoked when the thumbstick is pressed right
    public UnityEvent onThumbstickPressCountReached; // Event invoked when the threshold count is reached

    public GameObject image1; // Reference to Image1 UI object
    public GameObject image2; // Reference to Image2 UI object

    private int pressCount = 0; // Counter for the number of thumbstick presses
    private bool reachedThreshold = false; // Flag indicating whether the press count threshold has been reached
    private const int threshold = 8; // Threshold for number of right thumbstick presses to trigger event

    private void Start()
    {
        // Get the right hand XR input device
        rightHandDevice = UnityEngine.XR.InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        // Create an InputAction for thumbstick input
        thumbstickAction = new InputAction("rightThumbstick", InputActionType.Value, "<XRController>{RightHand}/thumbstick");

        // Attach the thumbstickPerformed method to the performed event of the InputAction
        thumbstickAction.performed += OnThumbstickPerformed;

        // Enable the thumbstick action
        thumbstickAction.Enable();
    }

    private void OnThumbstickPerformed(InputAction.CallbackContext context)
    {
        // Get the value of the thumbstick input
        Vector2 thumbstickValue = context.ReadValue<Vector2>();

        // Log the thumbstick input value
        Debug.Log("Thumbstick Value: " + thumbstickValue);

        // Check if the thumbstick is pressed strictly to the right on the right controller
        if (thumbstickValue.x > 0 && Mathf.Abs(thumbstickValue.y) < 0.2f)
        {
            // Increment the press count if the threshold is not reached
            if (!reachedThreshold)
            {
                pressCount++;

                // Check if the press count reaches the threshold
                if (pressCount >= threshold)
                {
                    // Trigger the event for reaching the press count threshold
                    onThumbstickPressCountReached.Invoke();

                    // Set flag to indicate threshold reached
                    reachedThreshold = true;

                    // Enable Image2 and disable Image1
                    image1.SetActive(false);
                    image2.SetActive(true);
                }
                else
                {
                    // Trigger the event for thumbstick pressed right
                    onThumbstickRight.Invoke();

                    // Enable Image1 and disable Image2
                    image1.SetActive(true);
                    image2.SetActive(false);
                }
            }
        }
    }

    private void OnDisable()
    {
        // Detach the thumbstickPerformed method from the performed event of the InputAction
        thumbstickAction.performed -= OnThumbstickPerformed;

        // Disable the thumbstick action
        thumbstickAction.Disable();
    }
}