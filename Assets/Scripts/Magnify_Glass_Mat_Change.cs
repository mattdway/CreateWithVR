using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnify_Glass_Mat_Change : MonoBehaviour
{
    public Material Clear;
    public Material MagnifyGlass;
    // Start is called before the first frame update
    void Start()
    {
        //theMat = GetComponent<Renderer>().material;
        GetComponent<Renderer>().material = Clear;
    }

    public void SetMatClear()
    {
        GetComponent<Renderer>().material = Clear;
    }

    public void SetMatMagnifyGlass()
    {
        GetComponent<Renderer>().material = MagnifyGlass;
    }
}
