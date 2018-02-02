using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMasterController : MonoBehaviour {

	public float speed;
	public float jumpForce;
	public float rotationspeed;

	private PlayerAnimController anim;

	private bool moving, running;

	public enum PlayerStates
	{
		ON_GROUND = 0,
		ON_WALL = 1,
		JUMPING = 2,
		ON_AIR = 3,
		DEAD = 4
	}

	public PlayerStates state;

	void Start ()
	{
		anim = GetComponent<PlayerAnimController> ();

		moving = false;
		running = false;
	}

	void Update ()
	{
        if (transform.position.y < -40) state = PlayerStates.DEAD;
    }

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.contacts[0].normal == Vector3.up)
		{
			state = PlayerStates.ON_GROUND;
		}
		else if (collision.gameObject.tag == "ParedV")
		{
			state = PlayerStates.ON_WALL;
        }

	}

	private void OnCollisionExit(Collision collision)
	{
		if (state != PlayerStates.JUMPING) {
			state = PlayerStates.ON_AIR;
		}
    }

	private void OnTriggerEnter(Collider c) {
        if (c.gameObject.tag == "laser")
        {
            state = PlayerStates.DEAD;
        }
    }

	public bool onSurface() {
		return state == PlayerStates.ON_GROUND || state == PlayerStates.ON_WALL;
	}

	public void jumped() {
		//anim.jump ();
		state = PlayerStates.JUMPING;
	}

	public void move(bool m) {
		moving = m;
	}

	public bool isMoving() {
		return moving && state != PlayerStates.DEAD;
	}

	public void run(bool r) {
		running = r;
	}

	public bool isRunning() {
		return running;
	}
}
