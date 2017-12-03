using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class triggerDoor : MonoBehaviour {

	public bool opening = false;
	public bool closing = false;
	public Transform door;
	public PlayerController player;
	public float speed;
	public int maxOpenValue;
	private float currentValue=0;
	public Text doorText;

    private int nbrGoal1 = 3;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (opening) {
			if (player.GetCount () >= nbrGoal1)
				OpenDoor ();
			else {
				doorText.gameObject.SetActive (true);
				doorText.text = "Vous devez récuperer les "+ nbrGoal1 + " cubes avant de poursuivre ! Vous en avez " + player.GetCount() + " !";
			}
		}
		if (closing) {
			CloseDoor ();
			doorText.gameObject.SetActive (false);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.transform.name == "Player")
		{
			opening = true;
			closing = false;
		
		}	
	}

	void OnTriggerExit(Collider other)
	{
		if(other.transform.name == "Player")
		{
			opening = false;
			closing = true;

		}


	}

	void OpenDoor() {
		float movement = speed * Time.deltaTime;
		currentValue += movement;
		if (currentValue <= maxOpenValue) {
			door.position = new Vector3 (door.position.x, door.position.y + movement, door.position.z);
		} else {
			opening = false;
		}
	}

	void CloseDoor() {
		float movement = speed * Time.deltaTime;
		currentValue -= movement;
		if (currentValue >=0) {
			door.position = new Vector3 (door.position.x, door.position.y - movement, door.position.z);
		} else {
			closing = false;
		}
	}
}
