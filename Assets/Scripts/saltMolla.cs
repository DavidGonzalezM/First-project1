﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saltMolla : MonoBehaviour {
	private Rigidbody _rb;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	/// <summary>
	/// Raises the collision enter event.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnCollisionEnter (Collision col) {
		if (col.collider.tag == "molla")
			_rb.AddForce (0, 200, 0); 
	}
}
