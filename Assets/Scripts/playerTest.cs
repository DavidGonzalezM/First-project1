using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTest : MonoBehaviour
{
    private Vector3 _calculatev;
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
            _calculatev.x = speed;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            _calculatev.x = -speed;
        }
        else
        {
            _calculatev.x = 0;
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            _calculatev.z = speed;
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            _calculatev.z = -speed;
        }
        else
        {
            _calculatev.z = 0;
        }
        _calculatev.y = rb.velocity.y;
        rb.velocity = _calculatev;
    }

    void ManageJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}
