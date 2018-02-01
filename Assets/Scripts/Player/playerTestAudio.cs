using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTestAudio : MonoBehaviour
{
	public float speed;
	public float jumpForce;
	public float rotationspeed;

	private float _rotationX;
	private Quaternion _originalRotation;

	private Vector3 _calculatev;
	private Rigidbody _rb;
	private bool _sideWalking;

	private enum Audios {
		WALK_STEP = 0,
		RUN_STEP = 1
	}
	private float stepSilence = 15;
	private float stepCount = 0;
	private SoundController sc;

	void Start ()
	{
		sc = GetComponent<SoundController> ();

		_originalRotation = transform.localRotation;
		_rb = GetComponent<Rigidbody>();
		_sideWalking = false;
	}


	void Update ()
	{
		ManageCamera ();
		ManageMovement();
		ManageJump();
	}
	void ManageMovement()
	{

		if (Input.GetAxisRaw("Horizontal") > 0)
		{
			_calculatev.x = speed;
			if (stepCount == 0) {

			}
			stepCount += Time.deltaTime;
		}
		else if (Input.GetAxisRaw("Horizontal") < 0)
		{
			_calculatev.x = -speed;
		}
		else
		{
			_calculatev.x = 0;
		}

		if (Input.GetAxisRaw("Vertical") > 0)
		{
			_calculatev.z = speed;
		}
		else if (Input.GetAxisRaw("Vertical") < 0)
		{
			_calculatev.z = -speed;
		}
		else
		{
			_calculatev.z = 0;
		}

		if (!_sideWalking) _calculatev.y = _rb.velocity.y;
		else _calculatev.y = 0;

		_rb.velocity = _calculatev;
	}

	void ManageJump()
	{
		if (Input.GetButtonDown("Jump"))
		{
			_rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "ParedV")
		{
			_sideWalking = true;
		}
	}
	private void OnCollisionExit(Collision collision)
	{
		if (collision.gameObject.tag == "ParedV")
		{
			_sideWalking = false;
		}
	}
	void ManageCamera() {


		_rotationX += Input.GetAxis("Mouse X") * rotationspeed;


		var xQuaternion = Quaternion.AngleAxis(_rotationX, Vector3.up);

		transform.localRotation = _originalRotation * xQuaternion;

	}

}
