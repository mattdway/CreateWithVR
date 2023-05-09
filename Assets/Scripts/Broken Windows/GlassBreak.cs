using System.Collections;
using UnityEngine;

public class GlassBreak : MonoBehaviour
{
    public Transform brokenObject;
    public float magnitudeCol, Radius, Power, Upwards;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > magnitudeCol)
        {
            Destroy(gameObject);
            Instantiate(brokenObject, transform.position, transform.rotation);
            brokenObject.localScale = transform.localScale;
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