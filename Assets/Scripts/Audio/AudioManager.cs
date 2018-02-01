using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	[Range(0f, 1f)]
	public float globalVolume = 1f;
	
	public Sound[] sounds;
	public Sound music;

	private SoundController[] controllers;

	private GameObject audioSources;
	//private List<SoundManager> soundManagers;

	public static AudioManager instance;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
			return;
		}

		DontDestroyOnLoad (gameObject);

		//soundManagers = new List<SoundManager> ();

		audioSources = new GameObject ();
		audioSources.name = "Global Audio Sources";
		audioSources.transform.parent = transform;

		foreach(Sound s in sounds) {
			s.setup(audioSources.AddComponent<AudioSource> ());
			s.setVolume (globalVolume);
		}

		//volume = GlobalControl.instance.getMusicVol ();

		music.setup(audioSources.AddComponent<AudioSource> ());
		music.setVolume (globalVolume);

		music.loop (true);
		music.Play ();

		Debug.Log ("Playing music " + music.clip.name);
	}

	void Start() {
		
	}

	public float getVolume() {
		return globalVolume;
	}

	public void Play(Sound.SoundType t) {
		foreach (Sound s in sounds) {
			if (s.type == t) {
				s.Play ();
			}
		}
	}

	public void setSoundVolume(float vol) {
		foreach (Sound s in sounds) {
			s.setVolume (vol);
		}

		foreach (SoundController s in controllers) {
			s.setVolume (vol);
		}
	}

	public void setMusicVolume(float vol) {
		//music.setVolume (vol);
	}
}
