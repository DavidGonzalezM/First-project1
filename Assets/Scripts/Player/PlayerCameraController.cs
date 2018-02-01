using UnityEngine;
using System.Collections;

public class PlayerCameraController : MonoBehaviour
{

	private float _rotationX;
	private Quaternion _originalRotation;
	private float rotationspeed;

	// Use this for initialization
	void Start ()
	{
		_originalRotation = transform.localRotation;

		rotationspeed = GetComponent<PlayerMasterController> ().rotationspeed;
	}
	
	// Update is called once per frame
	void Update ()
	{
		ManageCamera ();
	}

	void ManageCamera() {
		_rotationX += Input.GetAxis("Mouse X") * rotationspeed;

		var xQuaternion = Quaternion.AngleAxis(_rotationX, Vector3.up);

		transform.localRotation = _originalRotation * xQuaternion;

	}
}

