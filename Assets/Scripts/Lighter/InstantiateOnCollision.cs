using UnityEngine;
using System.Collections;

public class InstantiateOnCollision : MonoBehaviour
{
    public GameObject prefabToInstantiate;
    public GameObject EverythingIsFineMeme;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Tag match: " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Lighter")
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                Instantiate(prefabToInstantiate, contact.point, Quaternion.identity);

                // Start coroutine to update the score
                StartCoroutine(ThisIsFine());
            }
        }
    }

    // Coroutine to update the score
    IEnumerator ThisIsFine()
    {
        EverythingIsFineMeme.gameObject.SetActive(true);

        // Wait for 1.5 seconds
        yield return new WaitForSeconds(10f);

        EverythingIsFineMeme.gameObject.SetActive(false);
    }
}