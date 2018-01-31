using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBodyController : MonoBehaviour
{
	public GameObject laserBullet;
	public float shootTime = 2;

	private Transform target;
	private Transform gun1;
	private Transform gun2;
	private bool shoot;
	private Animator anim;
	private SoundController fire;

	void Start ()
	{
		target = GameObject.FindGameObjectWithTag("Player").transform;
		shoot = true;
		gun1 = transform.GetChild(0);
		gun2 = transform.GetChild(1);
		anim = GetComponent<Animator>();
		fire = GetComponent<SoundController> ();
	}


	void Update ()
	{
		if (anim.GetBool("isShooting")) anim.SetBool("isShooting", false);
		transform.LookAt(target);
		transform.Rotate(-90,-90,0);
		RaycastHit hit;
		Physics.Raycast(transform.position, target.position - transform.position, out hit);
		if (shoot && hit.collider.gameObject.tag == "Player")
		{
			ShootLasers();
			anim.SetBool("isShooting",true);
			shoot = false;
			Invoke("SetShootToTrue", shootTime);
		}
	}

	void ShootLasers()
	{
		GameObject laser1 = Instantiate(laserBullet, gun1.position, transform.rotation);
		GameObject laser2 = Instantiate(laserBullet, gun2.position, transform.rotation);
		laser1.transform.Rotate(0, 0, -90);
		laser2.transform.Rotate(0, 0, -90);

		fire.Play ();
	}

	private void SetShootToTrue()
	{
		shoot = true;
	}
}

