using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour {

	List<Sound> sounds;
	//List<AudioSource> sources;

	public float pitchVar;
	//public float playOnStart = false;
	//public float playDelay = 0;
	public GameObject[] audioSources;

	// Use this for initialization
	void Start () {
		sounds = new List<Sound> ();

		foreach (GameObject asource in audioSources) {
			Sound s = new Sound();

			if (asource != null) {
				AudioSource source = asource.GetComponent<AudioSource> ();
				//sources.Add (source);
				s = new Sound (source, pitchVar);
				s.setVolume (AudioManager.instance.getVolume ());
			}

			sounds.Add(s);
		}

		/*
		if (playOnStart) {
			if (playDelay > 0)
				StartCoroutine (WaitForPlay (playDelay));
			else
				sound.Play ();
		}
		*/
	}

	/*IEnumerator WaitForPlay(float t) {
		yield return new WaitForSeconds(t);
		Play ();
	}*/
	
	// Update is called once per frame
	void Update () {
		
	}

	public void setVolume(int i, float vol) {
		sounds[i].setVolume (vol);
	}

	public void setVolume(float vol) {
		foreach (Sound s in sounds) {
			s.setVolume (vol);
		}
	}

	public void Play(int i) {
		sounds[i].Play ();
	}

	public void Play() {
		foreach (Sound s in sounds) {
			s.Play ();
		}
	}
}
