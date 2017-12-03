using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformTrigger : MonoBehaviour {
    public GameObject wall;
    private float t = 0.0f;

    public void Update()
    {
       t = t - Time.deltaTime;
    }

	private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            wall.GetComponent<Animator>().SetBool("triggerEnter", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            wall.GetComponent<Animator>().SetBool("triggerEnter", false);
            t = 0.0f;
            if (t < 0)
            {
                wall.GetComponent<Animator>().SetBool("triggerEnter", true);
            }
        }
    }
}
