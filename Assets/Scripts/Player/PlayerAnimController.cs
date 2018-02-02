using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerAnimController : MonoBehaviour
{

	private Animator anim;
	private PlayerMasterController player;

	private bool wall, Jump, sprint, air, death, dead;

	// Use this for initialization
	void Start ()
	{
		player = GetComponent<PlayerMasterController> ();

		anim = GetComponent<Animator>();
		wall = false;
		Jump = false;
		sprint = false;
		air = false;
		death = false;
		dead = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		//*
		if (player.state == PlayerMasterController.PlayerStates.ON_GROUND) {
			sprint = player.isRunning ();
			wall = false;
			Jump = false;
			air = false;
		} else if (player.state == PlayerMasterController.PlayerStates.JUMPING) {
			Jump = true;
			wall = false;
		} else if (player.state == PlayerMasterController.PlayerStates.ON_WALL) {
			Jump = false;
			air = false;
		} else if (player.state == PlayerMasterController.PlayerStates.ON_AIR) {
			air = true;
			Jump = false;
			wall = false;
			sprint = false;
		} else if (player.state == PlayerMasterController.PlayerStates.DEAD) {
			if (!dead) {
				reset ();
				death = true;
				dead = true;
				StartCoroutine (WaitForExit (4));
			}
		}

		if (player.state != PlayerMasterController.PlayerStates.DEAD && dead) {
			death = false;
		}

		setBools (wall, Jump, sprint, air, death);
		/*/
		bool sideWalking = player.state == PlayerMasterController.PlayerStates.ON_WALL;

		if (player.onSurface()) {
			jump = false;
			anim.SetBool ("air", false);
			anim.SetBool("Jump", false);

			if (sideWalking && !wall) {
				wall = true;
				anim.SetBool ("wall", true);
				anim.speed = 1.0F;
			}
		} else if (player.state == PlayerMasterController.PlayerStates.ON_AIR) {
			if (!sideWalking && wall) {
				wall = false;
				anim.SetBool ("wall", false);
				anim.speed = 1.0F;
			} else if(!jump) {
				anim.SetBool ("air", true);
				anim.SetBool ("Jump", false);
				anim.speed = 1.0F;
			}
		} else if (player.state == PlayerMasterController.PlayerStates.DEAD) {
			if (!dead) {
				dead = true;
				anim.SetBool ("death", true);
			} else {
				anim.SetBool ("death", false);
			}
		}
		//*/
	}

	IEnumerator WaitForExit(float t) {
		yield return new WaitForSeconds(t);
		SceneManager.LoadScene (0);
	}

	public void reset() {
		wall = false;
		Jump = false;
		sprint = false;
		air = false;
		death = false;
		setBools (wall, Jump, sprint, air, death);
	}

	void setBools (bool wall, bool Jump, bool sprint, bool air, bool death) {
		if (anim.GetBool ("wall") != wall)
			anim.SetBool ("wall", wall);

		if (anim.GetBool ("Jump") != Jump)
			anim.SetBool ("Jump", Jump);

		if (anim.GetBool ("sprint") != sprint)
			anim.SetBool ("sprint", sprint);

		if (anim.GetBool ("air") != air)
			anim.SetBool ("air", air);

		if (anim.GetBool ("death") != death)
			anim.SetBool ("death", death);
	}
}

