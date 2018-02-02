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
    private Animator anim;

	public enum PlayerStates
	{
		ON_SURFACE = 0,
		ON_AIR = 1,
		DEAD = 3
	}

	public PlayerStates state;

	void Start ()
	{
        anim = GetComponent<Animator>();
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

        anim.SetBool("air", false);

		if (collision.gameObject.tag == "ParedV")
		{
			onWall = true;
            anim.SetBool("wall", true);
            anim.speed = 1.0F;
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
            anim.SetBool("wall", false);
            anim.speed = 1.0F;
        }
        else
        {
            anim.SetBool("air", true);
            state = PlayerStates.ON_AIR;
            anim.SetBool("Jump", false);
            anim.speed = 1.0F;
        }
    }

	private void OnTriggerEnter(Collider c) {
        if (c.gameObject.tag == "laser")
        {
            state = PlayerStates.DEAD;
            anim.SetBool("death", true);
        }
    }

	public bool canJump() {
		return onGround;
	}

	public bool sideWalking() {
		return onWall;
	}

	public void jumped() {
        anim.SetBool("air", true);
        anim.SetBool("Jump", false);
        anim.speed = 1.0F;
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
