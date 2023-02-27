using UnityEngine;

public class InstantiateOnCollision : MonoBehaviour
{
    public GameObject prefabToInstantiate;

    private void OnCollisionEnter(Collision collision)
    {
<<<<<<< HEAD
        //Debug.Log("Tag match: " + collision.gameObject.tag);
=======
        Debug.Log("Tag match: " + collision.gameObject.tag);
>>>>>>> 49cec427c63c30460c272358328f17331af70754
        if (collision.gameObject.tag == "Lighter")
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                Instantiate(prefabToInstantiate, contact.point, Quaternion.identity);
            }
        }
    }
}