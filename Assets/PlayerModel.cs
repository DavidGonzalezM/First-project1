using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour {

    public Vector3 Position;
    public Quaternion Rotation;

	public float PlayerSpeed = 6;
	public float RotationSpeed = 100;

    public GameObject BulletPrefab;

    public Transform Muzzle1;
    public Transform Muzzle2;

    public float Cooldown = .1f;
    public bool CanShoot = true;
}
