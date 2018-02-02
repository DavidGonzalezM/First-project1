using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivation : MonoBehaviour {

	public GameObject playerModel;
	public GameObject pathToReveal;

	private bool activated;

	// Use this for initialization
	void Start () {
		activated = false;
	}
	
	// Update is called once per frame
	void Update () {
		float dist = Vector3.Distance (transform.position, playerModel.transform.position);

		if (dist < 4 && facingButton()) {
			if (Input.GetKeyDown (KeyCode.E)) {
				activated = true;
				pathToReveal.GetComponent<PathReveal> ().checkReveal ();
			}
		}
	}

	bool facingButton() {
		Vector3 dir = (transform.position - playerModel.transform.position).normalized;
		float dotProd = Vector3.Dot (dir, playerModel.transform.forward);

		return dotProd > 0.6;
	}

	public bool isActivated() {
		return activated;
	}
}
