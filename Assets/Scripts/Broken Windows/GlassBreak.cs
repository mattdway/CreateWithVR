using System.Collections;
using UnityEngine;

public class GlassBreak : MonoBehaviour
{
    public Transform BrokenObject;
    public float magnitudeCol, Radius, Power, Upwards;
    public AudioSource audioSource = null;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > magnitudeCol)
        {
            audioSource.Play();

            Destroy(gameObject);
            Instantiate(BrokenObject, transform.position, transform.rotation);
            BrokenObject.localScale = transform.localScale;
            Vector3 explosionPos = transform.position;
            Collider[] colliders = Physics.OverlapSphere(explosionPos, Radius);

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