using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMasterController : MonoBehaviour {

	public float speed;
	public float jumpForce;
	public float rotationspeed;

	private bool onGround;
	private bool onWall;
	private bool moving;

	public enum PlayerStates
	{
		ON_SURFACE = 0,
		ON_AIR = 1,
		DEAD = 3
	}

	public PlayerStates state;

	void Start ()
	{
		onGround = true;
		onWall = false;
		moving = false;
	}

	void Update ()
	{
        if (transform.position.y < -20) state = PlayerStates.DEAD;
    }

	private void OnCollisionEnter(Collision collision)
	{
		state = PlayerStates.ON_SURFACE;

		if (collision.gameObject.tag == "ParedV")
		{
			onWall = true;
		}
		if (collision.contacts[0].normal == Vector3.up)
		{
			onGround = true;
		}
	}

	private void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.tag == "ParedV")
		{
			onWall = false;
		}
	}

	private void OnTriggerEnter(Collider c) {
        if (c.gameObject.tag == "laser")
        {
            state = PlayerStates.DEAD;
        }
    }

	public bool canJump() {
		return onGround;
	}

	public bool sideWalking() {
		return onWall;
	}

	public void jumped() {
		state = PlayerStates.ON_AIR;
		onGround = false;
	}

	public void move(bool m) {
		moving = m;
	}

	public bool isMoving() {
		return moving && state != PlayerStates.DEAD;
	}
}
