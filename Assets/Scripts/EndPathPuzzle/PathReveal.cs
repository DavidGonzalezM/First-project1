using UnityEngine;
using System.Collections;

public class PathReveal : MonoBehaviour
{
	public GameObject[] buttons;

	private bool reveal;

	// Use this for initialization
	void Start ()
	{
		reveal = false;

		gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (reveal)
			gameObject.SetActive (true);
	}

	public void checkReveal() {
		foreach (GameObject button in buttons) {
            if (!button.GetComponent<ButtonActivation>().isActivated())
                return;
		}
        reveal = true;
        gameObject.SetActive(true);

    }
}

