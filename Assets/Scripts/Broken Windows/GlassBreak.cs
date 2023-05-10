using System.Collections;
using UnityEngine;

public class GlassBreak : MonoBehaviour
{
    public Transform BrokenObject;
    public float magnitudeCol, Radius, Power, Upwards;
    private AudioSource audioSource = null;

    //Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Debug.Log("Audio Clip: " + audioSource.clip.name);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > magnitudeCol)
        {
            if (audioSource.clip == null)
            {
                Debug.LogError("Audio clip not assigned to AudioSource component!");
                return;
            }

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