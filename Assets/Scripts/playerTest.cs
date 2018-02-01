using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTest : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private Rigidbody rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	

	void Update ()
    {
        ManageMovement();
        ManageJump();
    }
    void ManageMovement()
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

    void ManageJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
