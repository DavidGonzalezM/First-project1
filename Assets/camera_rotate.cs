using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_rotate : MonoBehaviour {
	public float rotationspeed;
	private float _rotationY;
	private Quaternion _originalRotation;
	// Use this for initialization
	void Start () {
		_originalRotation = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
		_rotationY += Input.GetAxis("Mouse Y") * rotationspeed;
		var yQuaternion = Quaternion.AngleAxis(_rotationY, Vector3.left);

		transform.localRotation = _originalRotation * yQuaternion;
	}
}
