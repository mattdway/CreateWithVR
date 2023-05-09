using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;

/// <summary>
/// Apply forward force to instantiated prefab
/// </summary>
public class Launch_Staple_With_Count : MonoBehaviour
{
    [Tooltip("The projectile that's created")]
    public GameObject projectilePrefab = null;

    [Tooltip("The point that the project is created")]
    public Transform startPoint = null;

    [Tooltip("The speed at which the projectile is launched")]
    public float launchSpeed = 1.0f;

    // Create variable to hold staple count
    [SerializeField] int stapleCount = 25;
    // Create varialbe to link and populate TextMeshPro
    [SerializeField] TextMeshProUGUI Text;

    // Start is called before the first frame update
    void Start()
    {
        // Finds and adds the first active loaded object that matches the specified type
        // Text = FindObjectOfType<TextMeshProUGUI>();

        // Per https://gamedev.stackexchange.com/questions/132569/how-do-i-find-an-object-by-type-and-name-in-unity-using-c/132575
        // Find GameObject by both name and type
        Text = GameObject.Find("Staples_Remaining_Text (TMP)").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // Write text and variable value to TextMeshPro, updated once per frame
        Text.text = "Staples Remaining: " + stapleCount;
    }

    public void Fire()
    {
        // Check to see if stapleCount is greater than 0
        if (stapleCount > 0)
        {
            // Instantiate projectile prefab with start position and start rotation
            GameObject newObject = Instantiate(projectilePrefab, startPoint.position, startPoint.rotation);

            if (newObject.TryGetComponent(out Rigidbody rigidBody))
            {
                // Call ApplyForce method
                ApplyForce(rigidBody);
            }
        }
    }

    private void ApplyForce(Rigidbody rigidBody)
    {
        // Apply force and speed to projectile
        Vector3 force = startPoint.forward * launchSpeed;
        rigidBody.AddForce(force);

        // Reduce stapleCount by one
        stapleCount -= 1;
    }

    public void Reload()
    {
        // When called set stapleCount back to starting value of 25
        stapleCount = 25;
    }
}