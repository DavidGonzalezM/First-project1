using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Application : MonoBehaviour {

	public static Transform ModelRoot;
	public static Transform ControllerRoot;
	public static Transform ViewRoot;

	// Use this for initialization
	void Awake () {
		ModelRoot = GameObject.Find ("Model").transform;
		ControllerRoot = GameObject.Find ("Controller").transform;
		ViewRoot = GameObject.Find ("View").transform;
	}
	


	// Update is called once per frame
	void Update () {
		
	}
}
