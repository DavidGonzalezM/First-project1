using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTest : MonoBehaviour
{

    public float speed;

	void Start ()
    {
		
	}
	

	void Update ()
    {
		if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);
        }
        if (Input.GetAxisRaw("Vertical") > 0)
        {
            transform.Translate(transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            transform.Translate(-transform.forward * speed * Time.deltaTime);
        }

    }
}
