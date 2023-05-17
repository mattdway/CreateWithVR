// This script is attached to an object that can be destroyed on collision with another object.
using System.Collections;
using UnityEngine;

public class GlassBreak : MonoBehaviour
{
    // Public variables that can be edited from the Inspector.
    public Transform BrokenObject; // A transform that represents the broken object that will be instantiated when this object is destroyed.
    public float magnitudeCol, Radius, Power, Upwards; // The minimum collision magnitude, explosion radius, explosion power and upwards modifier.
    public AudioSource audioSource = null; // An AudioSource component that will play a sound effect when the object is destroyed.

    // This function is called when a collision occurs with this object.
    void OnCollisionEnter(Collision collision)
    {
        //Get Audio Souce Component
        audioSource = GameObject.Find("Glass_Break_Audio").GetComponent<AudioSource>();

        // Check if the relative velocity of the collision is greater than the minimum magnitude required to break the object.
        if (collision.relativeVelocity.magnitude > magnitudeCol)
        {
            // If the collision is strong enough, play the sound effect.
            audioSource.Play();

            // Destroy the pane of glass the object collided with.  Either: Room_Modern_Window_Glass_Left, Room_Modern_Window_Glass_Middle or Room_Modern_Window_Glass_Right
            Destroy(gameObject);

            // Destroy the westWindowCollider collision game object
            GameObject westWindowCollider = GameObject.Find("West_Window_Collider");
            Destroy(westWindowCollider);

            // Instantiate a broken object at the position and rotation of this object.
            Instantiate(BrokenObject, transform.position, transform.rotation);
            BrokenObject.localScale = transform.localScale;

            // Create an explosion force that affects all colliders within a certain radius from the position of this object.
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, Radius);

            // For each collider that is within the explosion radius, get the Rigidbody component attached to it (if it exists).
            // If it does, add an explosion force to the Rigidbody using the explosion power, radius, and upwards modifier, scaled by the relative velocity magnitude of the collision that caused the explosion.
            foreach (Collider hit in colliders)
            {
                Rigidbody rb = hit.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    rb.AddExplosionForce(Power * collision.relativeVelocity.magnitude, explosionPos, Radius, Upwards);
                }
            }
        }
    }
}