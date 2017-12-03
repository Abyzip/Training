using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformTrigger2 : MonoBehaviour {
    public GameObject wall;

	public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            wall.GetComponent<Animator>().SetBool("triggerEnter", true);
        }
    }
}
