using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ascensorController : MonoBehaviour {
	private Rigidbody _rb;
	// Use this for initialization
	void Start () {
		_rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerStay (Collider col) {
		Debug.Log (col.tag);
		if (col.tag == "player")
			StartCoroutine("MoveUp");
}
		
	IEnumerator MoveUp (){
		_rb.AddForce (0, 10, 0);
		yield return new WaitForSeconds(5);
		_rb.AddForce(0,-10,0);
	}
}
		
