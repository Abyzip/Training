using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
        if(gameObject.name == "death wall cross")
        {
            transform.Rotate(new Vector3(0, 0, 30) * Time.deltaTime);
        }
        else
		transform.Rotate(new Vector3(0, 30, 0) * Time.deltaTime);
	}
}
