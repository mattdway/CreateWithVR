using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRecord : MonoBehaviour
{
    public Vector3 RotateAmount;
    private RecordHandleMove _songOver;

    //Start is called before the first frame update
    void Start()
    {
        //Read the value of the public variable songOver from the RecordHandleMove script
        _songOver = GameObject.Find("Speaker_RecordPlayer_Handle").GetComponent<RecordHandleMove>();
    }

    //Update is called once per frame
    void Update()
    {
        //Debug.Log("_songOver.songOver = " + _songOver.songOver);
        if (_songOver.songOver == false)
        {
            //Debug.Log("You are in the false if statement");
            transform.Rotate(RotateAmount);
        }
        if (_songOver.songOver == true)
        {
            //Debug.Log("You are in the true if statement");
            RotateAmount = new Vector3(0, 0, 0);
        }
    }
}