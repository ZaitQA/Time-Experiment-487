using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour {

	private Rigidbody rb;
	public int speed;
	public int tilt;
	private static bool isgun;
	public static string[] inventaire;

	public GameObject shot;
	public Transform ShotSpawn;
	
	private AudioSource soundGun;
	public AudioClip pan;

	public float fireRate = 0.5f;
	private float nextFire = 0.0f;

	void Update()
	{
		soundGun = GetComponent<AudioSource>();
		inventaire = GetComponent<PlayerController>().Inventaire;
		if(isgun == false)
			foreach (string objet in inventaire)
			{
				if (objet == "Pistolet")
					isgun = true;
			}
		if (Input.GetButton("Fire2") && Time.time > nextFire && isgun)
		{
			soundGun.clip = pan;
			soundGun.Play();
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
