using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBallLauncher : MonoBehaviour {
    public GameObject ball;
    public AudioClip music;

    private AudioSource sourceLevel;
    private AudioSource source;

    void Awake()
    {
        sourceLevel = GameObject.FindGameObjectWithTag("level").GetComponent<AudioSource>();
        source = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            ball.GetComponent<Animator>().SetBool("TriggerEnter", true);
            ball.GetComponent<Animator>().Play("animFinalBall");
            sourceLevel.Pause();
            source.PlayOneShot(music);
        }
        Debug.Log(ball.GetComponent<Animator>().GetBool("TriggerEnter"));
    }
}
