using UnityEngine;
using System.Collections;

public class BlinkingSquare : MonoBehaviour
{
    public float blinkInterval = 0.5f;  // The time interval between blinks in seconds
    public Color blinkColor = Color.blue; // The color to use when blinking
    public Material offMaterial;    // The material used when blinking is off

    private Material originalMaterial;  // The original material of the square plane
    private Material blinkMaterial;     // The material used when blinking
    private Renderer squareRenderer;    // The renderer component of the square plane

    private void Start()
    {
        squareRenderer = GetComponent<Renderer>();
        originalMaterial = squareRenderer.material;
        blinkMaterial = new Material(originalMaterial);
        blinkMaterial.color = blinkColor;
        StartCoroutine(BlinkRoutine());
    }

    private IEnumerator BlinkRoutine()
    {
        while (true)
        {
            // Enable blinking by setting the blink material
            squareRenderer.material = blinkMaterial;
            yield return new WaitForSeconds(blinkInterval);

            // Disable blinking by setting the off material
            squareRenderer.material = offMaterial;
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}