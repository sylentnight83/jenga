using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour {
    void OnSelect()
    {
        print("On Select");
        GetComponent<Renderer>().material.color = new Color(0, 255, 0); //C sharp
    }

    void OnGaze()
    {

    }
}
