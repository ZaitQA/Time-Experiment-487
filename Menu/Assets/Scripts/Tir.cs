using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour {

	private Rigidbody rb;
	public int speed;
	public int tilt;
	private static bool isgun;
	public static string arme;

	public GameObject pistolet;
	public Transform ShotSpawn;
	
	private AudioSource soundGun;

	public AudioClip pan;
	public AudioClip assaut;
	public AudioClip pompe;

	public float fireRate = 0.5f;
	private float nextFire = 0.0f;
	public static string[] inventaire;



	void Update()
	{
		soundGun = GetComponent<AudioSource>();
		arme = GetComponent<PlayerController>().armes[0];

		if (arme == "pistolet")
		{
			isgun = true;
			fireRate = 0.75f;
		}
		if (arme == "assaut")
		{
			isgun = true;
			fireRate = 0.3f;
		}
		if (arme == "pompe")
		{
			isgun = true;
			fireRate = 1.5f;
		}

		if (Input.GetButton("Fire2") && Time.time > nextFire && isgun)
		{
			if (arme == "pistolet")
			{
				soundGun.clip = pan;
				soundGun.Play();
				PhotonNetwork.Instantiate("Capsule", ShotSpawn.position, ShotSpawn.rotation, 0);
				nextFire = Time.time + fireRate;
			}
			if (arme == "assaut")
			{
				soundGun.clip = pan;
				soundGun.Play();
				PhotonNetwork.Instantiate("Capsule", ShotSpawn.position, ShotSpawn.rotation,0);
				nextFire = Time.time + fireRate;
			}
			if (arme == "pompe")
			{
				soundGun.clip = pan;
				soundGun.Play();
				PhotonNetwork.Instantiate("Capsule", ShotSpawn.position,
					new Quaternion(ShotSpawn.rotation.x + 0.1f, ShotSpawn.rotation.y, ShotSpawn.rotation.z, ShotSpawn.rotation.w),0);
				PhotonNetwork.Instantiate("Capsule", ShotSpawn.position,
					new Quaternion(ShotSpawn.rotation.x, ShotSpawn.rotation.y + 0.1f, ShotSpawn.rotation.z, ShotSpawn.rotation.w),0);
				PhotonNetwork.Instantiate("Capsule", ShotSpawn.position,
					new Quaternion(ShotSpawn.rotation.x, ShotSpawn.rotation.y, ShotSpawn.rotation.z + 0.1f, ShotSpawn.rotation.w),0);
				PhotonNetwork.Instantiate("Capsule", ShotSpawn.position,
					new Quaternion(ShotSpawn.rotation.x - 0.1f, ShotSpawn.rotation.y, ShotSpawn.rotation.z, ShotSpawn.rotation.w),0);
				PhotonNetwork.Instantiate("Capsule", ShotSpawn.position,
					new Quaternion(ShotSpawn.rotation.x, ShotSpawn.rotation.y - 0.1f, ShotSpawn.rotation.z, ShotSpawn.rotation.w),0);
				PhotonNetwork.Instantiate("Capsule", ShotSpawn.position,
					new Quaternion(ShotSpawn.rotation.x, ShotSpawn.rotation.y, ShotSpawn.rotation.z - 0.1f, ShotSpawn.rotation.w),0);


				nextFire = Time.time + fireRate;
			}

		}
	}


	public static bool Isgun
	{
		get { return isgun; }
		set { isgun = value; }
	}
}
