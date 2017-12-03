using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL1platformElevator : MonoBehaviour {

    public GameObject nextPlatform;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTrigger(Collider collider)
    {
        Debug.Log("entré");
        if (collider.gameObject.name == "Player")
            Debug.Log("activé");
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("dsv");
    }
}
