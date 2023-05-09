using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Apply forward force to instantiated prefab
/// </summary>
public class Launch_Dart_With_Count : MonoBehaviour
{
    [Tooltip("The projectile that's created")]
    public GameObject projectilePrefab = null;

    [Tooltip("The point that the project is created")]
    public Transform startPoint = null;

    [Tooltip("The speed at which the projectile is launched")]
    public float launchSpeed = 1.0f;

    // Create variable to hold dart count
    public int DartCount = 25;

    // Create private variable to hold initial dart count
    private int _initalDartCount;

    // Creates a private variable that points to the Dart_Game_Activation script
    private Dart_Game_Activation _dartGameActivation;

    // Create varialbe to link and populate TextMeshPro
    [SerializeField] TextMeshProUGUI Text;

    // Create varialbe to link the nerfGunTrigger GameObject
    [SerializeField] GameObject nerfGunTrigger;

    // Create varialbe for the animator
    Animator m_animator;
    
    // Start is called before the first frame update
    void Start()
    {
        // Finds and adds the first active loaded object that matches the specified type - deprecated (original) code
        // Text = FindObjectOfType<TextMeshProUGUI>();

        // Sets the _initalDartCount to the DartCount
        _initalDartCount = DartCount;

        // Per https://gamedev.stackexchange.com/questions/132569/how-do-i-find-an-object-by-type-and-name-in-unity-using-c/132575
        // Find GameObject by both name and type
        Text = GameObject.Find("Darts_Remaining_Text (TMP)").GetComponent<TextMeshProUGUI>();

        //Assign the animator at Start
        m_animator = nerfGunTrigger.GetComponent<Animator>();

        // Find the game object "Launcher_DartGun" and get the component Dart_Game_Activation to assign it to _dartGameActivation
        _dartGameActivation = GameObject.Find("Dart_Game_Activation").GetComponent<Dart_Game_Activation>();
    }

    // Update is called once per frame
    void Update()
    {
        // Write text and variable value to TextMeshPro, updated once per frame
        Text.text = "Darts Remaining: " + DartCount;
    }

    public void Fire()
    {
        //Trigger nerfGunTrigger pull and release animation
        m_animator.SetTrigger("Fire");

        // Check to see if DartCount is greater than 0
        if (DartCount > 0)
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

        // Reduce DartCount by one
        DartCount -= 1;
    }

    public void Reload()
    {
        if (_dartGameActivation.DartGameStarted == false)
        {
            // When called set DartCount back to starting value of 25.  Set Reload as your Select Exited and/or Select events.
            DartCount = _initalDartCount;
        }
    }
}