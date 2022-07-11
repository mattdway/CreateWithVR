using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDoorLightsOn : MonoBehaviour
{
    [SerializeField] GameObject door;
    [SerializeField] GameObject doorLightEffect;
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
   
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Light On Collision");

        if (other.gameObject.name == "Room_Modern_DoorHandle")
        {
            Debug.Log("Matched On Tag");
            doorLightEffect.SetActive(true);
        }
    }
}