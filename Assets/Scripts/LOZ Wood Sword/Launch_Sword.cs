using System.Runtime.CompilerServices;
using UnityEngine;

/// <summary>
/// Apply forward force to instantiated prefab
/// </summary>
public class Launch_Sword : MonoBehaviour
{
    [Tooltip("The projectile that's created")]
    public GameObject projectilePrefab = null;

    [Tooltip("The point that the project is created")]
    public Transform startPoint = null;

    [Tooltip("The speed at which the projectile is launched")]
    public float launchSpeed = 1.0f;

    [Tooltip("The audio source component attached to the game object")]
    public AudioSource audioSource = null;

    public void Fire()
    {
        GameObject newObject = Instantiate(projectilePrefab, startPoint.position, startPoint.rotation);
        if (newObject.TryGetComponent(out Rigidbody rigidBody))
        {
            ApplyForce(rigidBody);
        }
    }

    private void ApplyForce(Rigidbody rigidBody)
    {
        Vector3 force = startPoint.forward * launchSpeed;
        rigidBody.AddForce(force);
        PlaySound(1);
    }
    void PlaySound(int audioIndex)
    {
        if (audioIndex == 1)
        {
            audioSource.Play();
        }
    }
}