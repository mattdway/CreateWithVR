using UnityEngine;

public class BottleFlipChallengeLose : MonoBehaviour
{
    private bool _collisionActive = false;
    private float _collisionStartTime = 0f;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision detected with " + other.gameObject.name + " with tag " + other.gameObject.tag);
        if (other.tag == "Floor")
        {
            //Debug.Log("Tag check passed. Setting _collisionActive and _collisionStartTime");
            _collisionActive = true;
            _collisionStartTime = Time.time;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (_collisionActive && Time.time - _collisionStartTime >= 1f)
        {
            if (other.tag == "Floor")
            {
                //Debug.Log("Collision active for more than 1 second. Playing audio source file.");
                _audioSource.Play();
                _collisionActive = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Debug.Log("Setting _collisionActive to false");
        _collisionActive = false;
    }
}