using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour {
    public void OnGaze() {
        print("On");
        // GetComponent<Renderer>().material.color = new Color(0, 255, 0); //C sharp
    }

    public void OffGaze() {
        // print("Off");
    }
}
