using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour {
    public GameObject camera;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            
        }
    }
}
