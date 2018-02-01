using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTest : MonoBehaviour
{
    public float speed;
    public float jumpForce;
	public float rotationspeed;

	private float _rotationX;
	private Quaternion _originalRotation;

    private Vector3 _calculatev;
    private Rigidbody _rb;
    private bool _sideWalking;

    private bool canJump;
    private GameController _gc;

	void Start ()
    {
		_originalRotation = transform.localRotation;
        _rb = GetComponent<Rigidbody>();
        _sideWalking = false;
        canJump = true;
        _gc = GameObject.Find("GameController").GetComponent<GameController>();
	}
	

	void Update ()
    {
		ManageCamera ();
        ManageMovement();
        ManageJump();
    }
    void ManageMovement()
    {
        float vel;
        if (Input.GetKey(KeyCode.LeftShift)) vel = speed + 5;
        else vel = speed;

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            _calculatev = transform.right * vel;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            _calculatev = -transform.right * vel;
        }

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            _calculatev = transform.forward * vel;
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            _calculatev = -transform.forward * vel;
        }
        
        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            _calculatev.x = 0;
            _calculatev.z = 0;
        }

        if (!_sideWalking) _calculatev.y = _rb.velocity.y;
        else _calculatev.y = 0;
        if (transform.position.y < -20) _gc.Die();

        _rb.velocity = _calculatev;
    }

    void ManageJump()
    {
        
        if (Input.GetButtonDown("Jump"))
        {
            if (canJump)
            {
                _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                canJump = false;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ParedV")
        {
            _sideWalking = true;
        }
        if (collision.contacts[0].normal == Vector3.up)
        {
            canJump = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "ParedV")
        {
            _sideWalking = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "laser")
        {
            _gc.Die();
        }
    }
    void ManageCamera() {
		

		_rotationX += Input.GetAxis("Mouse X") * rotationspeed;


		var xQuaternion = Quaternion.AngleAxis(_rotationX, Vector3.up);

		transform.localRotation = _originalRotation * xQuaternion;

		}

}
