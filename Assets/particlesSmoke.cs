using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlesSmoke : MonoBehaviour {

    public PlayerMasterController PMC;
    private bool isMoving;

	// Use this for initialization
	void Start () {
        isMoving = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (PMC.isMoving() && !isMoving)
        {
            GetComponent<ParticleSystem>().Play();
            isMoving = true;
        }
        else if (!PMC.isMoving() && isMoving)
        {
            GetComponent<ParticleSystem>().Stop();
            isMoving = false;
        }
	}
}
