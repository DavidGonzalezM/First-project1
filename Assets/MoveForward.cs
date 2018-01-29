using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {
    [SerializeField]
    float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector3 newPos = Vector3.up * speed * Time.deltaTime;
        transform.position += transform.rotation * newPos;
	}
}
