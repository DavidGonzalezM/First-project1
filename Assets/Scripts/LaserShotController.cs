using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserShotController : MonoBehaviour
{

    public float laserVelocity = 10;
    public float lifetime = 5;

    void Start ()
    {
		
	}
	
	void Update ()
    {
        lifetime -= Time.deltaTime;
        if (lifetime <= 0) Destroy(gameObject);
        transform.position += transform.up * laserVelocity * Time.deltaTime;
    }
}
