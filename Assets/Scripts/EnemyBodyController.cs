using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBodyController : MonoBehaviour
{
	public GameObject laserBullet;
	public float shootTime = 2;

	private Transform _target;
	private Transform _gun1;
	private Transform _gun2;
	private bool _shoot;
	private Animator _anim;
	private SoundController _fire;

	void Start ()
	{
		_target = GameObject.FindGameObjectWithTag("Player").transform;
		_shoot = true;
		_gun1 = transform.GetChild(0);
		_gun2 = transform.GetChild(1);
		_anim = GetComponent<Animator>();
		_fire = GetComponent<SoundController> ();
	}


	void Update ()
	{
		if (_anim.GetBool("isShooting")) _anim.SetBool("isShooting", false);
		transform.LookAt(_target);
		transform.Rotate(-90,-90,0);
		RaycastHit hit;
		Physics.Raycast(transform.position, _target.position - transform.position, out hit);
		if (_shoot && hit.collider.gameObject.tag == "Player")
		{
			ShootLasers();
			_anim.SetBool("isShooting",true);
			_shoot = false;
			Invoke("SetShootToTrue", shootTime);
		}
	}

	void ShootLasers()
	{
		GameObject laser1 = Instantiate(laserBullet, _gun1.position, transform.rotation);
		GameObject laser2 = Instantiate(laserBullet, _gun2.position, transform.rotation);
		laser1.transform.Rotate(0, 0, -90);
		laser2.transform.Rotate(0, 0, -90);

		_fire.Play ();
	}

	private void SetShootToTrue()
	{
		_shoot = true;
	}
}

