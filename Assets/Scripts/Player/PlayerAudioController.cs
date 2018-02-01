using UnityEngine;
using System.Collections;

public class PlayerAudioController : MonoBehaviour
{
	public float stepSilence = 0.5f;

	private float stepCount = 0f;
	private bool wasMoving;

	private enum PlayerSounds
	{
		WALK_STEP = 0,
		RUN_STEP = 1,
		DEATH = 2,
		JUMP = 3,
		LAND = 4
	}

	private PlayerMasterController player;
	private SoundController sc;

	// Use this for initialization
	void Start ()
	{
		player = GetComponent<PlayerMasterController> ();
		sc = GetComponent<SoundController> ();

		wasMoving = player.isMoving ();
	}

	// Update is called once per frame
	void Update ()
	{
		ManageAudio ();
	}

	void ManageAudio() {
		bool moving = player.isMoving ();
		if(moving && !wasMoving) stepCount = stepSilence;

		if (player.state == PlayerMasterController.PlayerStates.ON_SURFACE && moving) {
			if (stepCount >= stepSilence) {
				sc.Play ((int)PlayerSounds.WALK_STEP);
				stepCount = 0f;
			}
			stepCount += Time.deltaTime;
		}

		wasMoving = moving;
	}

	private void OnCollisionEnter(Collision collision)
	{
		sc.Play ((int) PlayerSounds.LAND);
	}
}

