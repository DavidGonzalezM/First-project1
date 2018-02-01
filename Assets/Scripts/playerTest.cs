using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTest : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private Vector3 _calculatev;
    private Rigidbody _rb;
    private bool _sideWalking;

	void Start ()
    {
        _rb = GetComponent<Rigidbody>();
        _sideWalking = false;
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

        if (!_sideWalking) _calculatev.y = _rb.velocity.y;
        else _calculatev.y = 0;

        _rb.velocity = _calculatev;
    }

    void ManageJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ParedV")
        {
            _sideWalking = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ParedV")
        {
            _sideWalking = false;
        }
    }
}
