using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
	public int speed=500;
	private int count;
    private int countLevel;
    public Text countText;
	public Text textLevel;
    public Text FinishText;
    private Rigidbody rb;
    public GameObject spawn;
    public GameObject finalBall;
    public AudioClip music;

    private AudioSource sourceLevel;
    private AudioSource source;

    void Awake()
    {
        sourceLevel = GameObject.FindGameObjectWithTag("level").GetComponent<AudioSource>();
        source = GameObject.FindGameObjectWithTag("trigger").GetComponent<AudioSource>();
    }

    void Start () {
		rb = GetComponent<Rigidbody>();
		count = 0;
        countLevel = 0;
        SetCountText();
	}
	
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical= Input.GetAxis ("Vertical");

		Vector3 mouvment = new Vector3 (moveHorizontal, 0, moveVertical);
        
		rb.AddForce(mouvment* speed * Time.deltaTime);

        if(Input.GetKey(KeyCode.Space))
        {
            transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y, spawn.transform.position.z);
            rb.velocity = Vector3.zero;
            finalBall.GetComponent<Animator>().Rebind();
        }

	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.tag == "cube")
		{
			other.gameObject.SetActive(false);
            SoundEffectsHelper.Instance.PlayCoin();
			count = count + 1;
			SetCountText();
		}

		else if(other.gameObject.tag == "death")

        {
            transform.position = new Vector3(spawn.transform.position.x, spawn.transform.position.y,spawn.transform.position.z);
            rb.velocity = Vector3.zero;
            finalBall.GetComponent<Animator>().Rebind();
            
            if(count == 0)
            {
                source.Stop();
                sourceLevel.UnPause();
            }
            SoundEffectsHelper.Instance.PlayDeath();
        }

		else if(other.gameObject.tag == "boost")
		{
			Vector3 mouvment = new Vector3 (0, 0, 50);
			rb.AddForce(mouvment* speed * Time.deltaTime);
		}

        else if (other.gameObject.tag == "checkpoint")
        {
            spawn = other.gameObject;
        }

        else if (other.gameObject.tag == "lvl1")
        {
            countLevel = 1;
            SetLevelText();
        }

        else if (other.gameObject.tag == "lvl2")
        {
            countLevel = 2;
            SetLevelText();
        }

        else if (other.gameObject.tag == "lvl3")
        {
            countLevel = 3;
            SetLevelText();
        }

        else if (other.gameObject.tag == "bloc")
        {
            if(other.gameObject.name == "Ice door" && count > 0)
            { 
                other.gameObject.SetActive(false);
            }

            if (other.gameObject.name == "Ice door 2" && count == 5)
            {
                other.gameObject.SetActive(false);
            }
        }

        else if (other.gameObject.tag == "finish")
        {
            gameObject.SetActive(false);
            SetFinishText();
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "wall")
        {
            SoundEffectsHelper.Instance.PlayHit();
        }
    }

        void SetCountText() {
		countText.text = "Pièces : " + count.ToString ();
	}

    void SetLevelText()
    {
        textLevel.text = "Level " + countLevel.ToString();
    }

    void SetFinishText()
    {
        FinishText.text = "You win !";
    }

    public int GetCount() {
		return count;
	}
}
