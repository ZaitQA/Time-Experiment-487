using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : PlayerController {

	private Rigidbody rb;
	public int speed;
	public int tilt;
	private static bool isgun;

	public GameObject shot;
	public Transform ShotSpawn;

	public float fireRate = 0.5f;
	private float nextFire = 0.0f;

	void Update()
	{
		inventaire = GetComponent<PlayerController>().Inventaire;
		if(isgun == false)
			foreach (string objet in inventaire)
			{
				if (objet == "Pistolet")
					isgun = true;
			}
		if (Input.GetButton("Fire2") && Time.time > nextFire && isgun)
		{
			Instantiate(shot, ShotSpawn.position, ShotSpawn.rotation);
			nextFire = Time.time + fireRate;

		}
	}
	
	public static bool Isgun
	{
		get { return isgun; }
		set { isgun = value; }
	}
}
