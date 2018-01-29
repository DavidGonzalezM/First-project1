using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour {

	[SerializeField]
	float _speed = 300;

	void Update () {
		transform.Rotate(new Vector3(0,0,_speed * Time.deltaTime));
	}
}
