using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator2 : MonoBehaviour {

	public Transform obj;
	public Transform bridge;

	private float initValue;
	public bool isRotating=false;
	// Use this for initialization
	void Start () {
		initValue=obj.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (isRotating) {
			obj.Rotate (new Vector3 (0, 100, 0) * Time.deltaTime);
			bridge.Rotate (new Vector3 (0, 20, 0) * Time.deltaTime);
		}

		else {
			if (obj.position.z != initValue) {
				obj.Rotate (new Vector3 (0, 20, 0) * Time.deltaTime);
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.transform.name == "trigger2")
		{
			isRotating = true;

		}	
	}

	void OnTriggerExit(Collider other)
	{
		if(other.transform.name == "trigger2")
		{
				isRotating = false;

		}


	}
		
}
