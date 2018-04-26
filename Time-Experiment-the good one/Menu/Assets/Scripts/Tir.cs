using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour {

	private Rigidbody rb;
	public int speed;
	public int tilt;

	public GameObject shot;
	public Transform ShotSpawn;

	public float fireRate = 0.5f;
	private float nextFire = 0.0f;

	void Update()
	{
		if (Input.GetButton("Fire2") && Time.time > nextFire)
		{
			Instantiate(shot, ShotSpawn.position, ShotSpawn.rotation);
			nextFire = Time.time + fireRate;

		}
	}

}
