using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaEnnemi : MonoBehaviour {
	
	public bool direction=true;
	public Transform t;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (direction)
			t.position = new Vector3 (t.position.x +(speed* Time.deltaTime), t.position.y, t.position.z);
		else
			t.position = new Vector3 (t.position.x-(speed* Time.deltaTime), t.position.y, t.position.z);
		
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.transform.name == "triggerRight")
		{
			direction = false;

		}	
		else if(other.transform.name == "triggerLeft")
		{
			direction = true;

		}	
	}
}
