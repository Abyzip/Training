using UnityEngine;
using System.Collections;

public class SoundEffectsHelper : MonoBehaviour
{
	public static SoundEffectsHelper Instance;

	public AudioClip music;
    public AudioClip hit;
    public AudioClip death;
    public AudioClip coin;

    void Awake()
	{
		Instance = this;
	}

	public void PlayMusic()
	{
		MakeSound(music);
	}

    public void PlayHit()
    {
        MakeSound(hit);
    }

    public void PlayDeath()
    {
        MakeSound(death);
    }

    public void PlayCoin()
    {
        MakeSound(coin);
    }

    private void MakeSound(AudioClip originalClip)
	{
		AudioSource.PlayClipAtPoint(originalClip, transform.position);
	}
}