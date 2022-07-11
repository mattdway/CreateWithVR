using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce_Sound : MonoBehaviour
{
    public AudioSource bounceSource;
    // Start is called before the first frame update
    void Start()
    {
        bounceSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        bounceSource.volume = Mathf.Clamp01(collision.relativeVelocity.magnitude / 20);
        bounceSource.Play ();
    }
}
