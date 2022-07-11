using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dart_Audio_Impact : MonoBehaviour
{

    void OnCollisionEnter()  //Plays Sound Whenever collision detected
    {
        GetComponent<AudioSource>().Play();
    }

}
