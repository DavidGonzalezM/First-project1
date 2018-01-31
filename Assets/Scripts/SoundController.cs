using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

	Sound sound;
	AudioSource source;

	public float pitchVar;
	//public float playOnStart = false;
	//public float playDelay = 0;
	public GameObject audioObj;

	// Use this for initialization
	void Start () {
		source = audioObj.GetComponent<AudioSource> ();

		sound = new Sound (source, pitchVar);
		sound.setVolume (AudioManager.instance.getVolume ());

		/*
		if (playOnStart) {
			if (playDelay > 0)
				StartCoroutine (WaitForPlay (playDelay));
			else
				sound.Play ();
		}
		*/
	}

	IEnumerator WaitForPlay(float t) {
		yield return new WaitForSeconds(t);
		sound.Play ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setVolume(float vol) {
		sound.setVolume (vol);
	}

	public void Play() {
		sound.Play ();
	}
}
