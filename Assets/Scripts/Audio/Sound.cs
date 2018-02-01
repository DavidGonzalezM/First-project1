using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound {

	public enum SoundType
	{
		BACKGROUND = 0,
		PLAYER_DEATH = 1,
		PLAYER_STEP = 2
	}

	public SoundType type;


	public AudioClip clip;

	[Range(0f, 1f)]
	public float volume = 1f;
	[Range(.1f, 3f)]
	public float pitch = 1f;

	//Rango de pitch random [-pitchVar, +pitchVar] alrededor del pitch original
	public float pitchVar;

	private float sourceVolume;
	private float sourcePitch;
	private AudioSource source;

	public Sound() {
		clip = null;
		source = null;
	}

	public Sound(AudioSource s) {
		source = s;
		clip = s.clip;

		volume = s.volume;
		pitch = s.pitch;
	}

	public Sound(AudioSource s, float pv) : this(s) {
		pitchVar = pv;
	}

	//Para el audio manager
	public void setup(AudioSource s) {
		source = s;
		source.clip = clip;
		source.volume = volume;
	}

	public void setVolume(float v) {
		if(source != null) source.volume = v * volume;
	}

	public void setPitchVar(float pv) {
		pitchVar = pv;
	}

	//Variación del pitch
	void randomPitch() {
		float r = (pitch + (Random.value - 0.5f) * 2f * pitchVar);
		source.pitch = Mathf.Max(Mathf.Min(r, 3f), .1f);
	}

	public void Play() {
		if (source != null) {
			randomPitch ();
			source.Play ();
		}
	}

	public void loop(bool isLoop) {
		if(source != null)
			source.loop = isLoop;
	}
}
