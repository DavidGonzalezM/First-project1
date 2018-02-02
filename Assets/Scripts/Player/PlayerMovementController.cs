using UnityEngine;
using System.Collections;

public class PlayerMovementController : MonoBehaviour
{
	private float speed;
	private float jumpForce;

    //private Animator anim;
	private Vector3 _calculatev;
	private Rigidbody _rb;
	private bool _sideWalking;

	private PlayerMasterController player;

    public float velocidad_correr = 1.0F;
    public float velocidad_saltar = 1.0F;

    // Use this for initialization
    void Start ()
	{
        //anim = GetComponent<Animator>();
		player = GetComponent<PlayerMasterController> ();
		speed = player.speed;
		jumpForce = player.jumpForce;

		_rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (player.state != PlayerMasterController.PlayerStates.DEAD) {
			ManageMovement ();
			ManageJump ();
		}
        //else
            //anim.SetBool("death", true);
    }

	void ManageMovement()
	{
		bool moving = false;

		_sideWalking = player.state == PlayerMasterController.PlayerStates.ON_WALL;

		_calculatev = new Vector3(0,0,0);

        float vel;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            vel = speed + 5;
            //anim.SetBool("sprint", true);
            //anim.speed = velocidad_correr;
			player.run(true);
        }
        else
        {
            vel = speed;
            //anim.SetBool("sprint", false);
            //anim.speed = 1.0F;
			player.run(false);
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
		{
			moving = true;
			_calculatev += transform.right * vel;
		}
		if (Input.GetAxisRaw("Horizontal") < 0)
		{
			moving = true;
			_calculatev -= transform.right * vel;
		}

		if (Input.GetAxisRaw("Vertical") > 0)
		{
			moving = true;
			_calculatev += transform.forward * vel;
		}
		if (Input.GetAxisRaw("Vertical") < 0)
		{
			moving = true;
			_calculatev -= transform.forward * vel;
		}

		if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
		{
			_calculatev.x = 0;
			_calculatev.z = 0;
			moving = false;
		}

		if (!_sideWalking)
			_calculatev.y = _rb.velocity.y;
		else if (_calculatev.y < 0)
			_calculatev.y = 0;

		_rb.velocity = _calculatev;
		player.move (moving);
	}

	void ManageJump()
	{

		if (Input.GetButtonDown("Jump"))
		{
			if (player.onSurface())
			{
				_rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
				player.jumped();
                //anim.SetBool("Jump", true);
                //anim.speed = velocidad_saltar;
            }
        }
    }
}

