using UnityEngine;

public class InstantiateOnCollision : MonoBehaviour
{
    public GameObject prefabToInstantiate;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Tag match: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Lighter")
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                Instantiate(prefabToInstantiate, contact.point, Quaternion.identity);
            }
        }
    }
}