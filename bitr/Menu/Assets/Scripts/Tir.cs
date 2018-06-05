using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour {

	private Rigidbody rb;
	public int speed;
	public int tilt;
	private static bool isgun;
	public string arme;

	public GameObject pistolet;
	public Transform ShotSpawnD;
	public Transform ShotSpawnA;
	public Transform ShotSpawnP;

	private AudioSource soundGun;

	public AudioClip pan;
	public AudioClip assaut;
	public AudioClip pompe;

	public float fireRate = 0.5f;
	private float nextFire = 0.0f;
	public static string[] inventaire;

	public int munPistolet = 0;
	public int chargeurPistolet = 12;
	public int munAssaut = 0;
	public int chargeurAssaut = 30;
	public int munPompe = 0;
	public int chargeurPompe = 5;
	public int currentChargeurPistolet;
	public int currentChargeurAssaut;
	public int currentChargeurPompe;
	public int a;
	public GameObject deagle;
	public GameObject M807;
	public GameObject M4;




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
		if (Input.GetKeyDown(KeyCode.R))
		{
			if (arme == "pistolet")
			{
				a = Math.Min(chargeurPistolet - currentChargeurPistolet, munPistolet);
				munPistolet -= a;
				currentChargeurPistolet += a;
				nextFire += 2;

			}
			if (arme == "assaut")
			{
				a = Math.Min(chargeurAssaut - currentChargeurAssaut, munAssaut);
				munAssaut -= a;
				currentChargeurAssaut += a;
				nextFire += 3;

			}
			if (arme == "pompe")
			{
				a = Math.Min(chargeurPompe - currentChargeurPompe, munPompe);
				munPompe -= a;
				currentChargeurPompe += a;
				nextFire += 4;

			}
		}

		if (Input.GetButton("Fire2") && Time.time > nextFire && isgun)
		{
			if (arme == "pistolet" && currentChargeurPistolet > 0)
			{
				GetComponent<PlayerController>().Anim.SetBool("isgun", true);
				PhotonView.Get(this).RPC("ActiveArme", PhotonTargets.All, "pistolet", true);
				soundGun.clip = pan;
				soundGun.Play();
				PhotonNetwork.Instantiate("pistolet", ShotSpawnD.position, ShotSpawnD.rotation, 0);
				currentChargeurPistolet -= 1;
				nextFire = Time.time + fireRate;
			}
			if (arme == "assaut" && currentChargeurAssaut > 0)
			{
				GetComponent<PlayerController>().Anim.SetBool("isgun", true);
				PhotonView.Get(this).RPC("ActiveArme", PhotonTargets.All, "assaut", true);

				soundGun.clip = pan;
				soundGun.Play();
				PhotonNetwork.Instantiate("assaut", ShotSpawnA.position, ShotSpawnA.rotation, 0);
				currentChargeurAssaut -= 1;
				nextFire = Time.time + fireRate;
			}
			if (arme == "pompe" && currentChargeurPompe > 0)
			{
				GetComponent<PlayerController>().Anim.SetBool("isgun", true);
				PhotonView.Get(this).RPC("ActiveArme", PhotonTargets.All, "pompe", true);
				soundGun.clip = pan;
				soundGun.Play();
				PhotonNetwork.Instantiate("pompe", ShotSpawnP.position,
					new Quaternion(ShotSpawnP.rotation.x + 0.1f, ShotSpawnP.rotation.y, ShotSpawnP.rotation.z, ShotSpawnP.rotation.w), 0);
				PhotonNetwork.Instantiate("pompe", ShotSpawnP.position,
					new Quaternion(ShotSpawnP.rotation.x, ShotSpawnP.rotation.y + 0.1f, ShotSpawnP.rotation.z, ShotSpawnP.rotation.w), 0);
				PhotonNetwork.Instantiate("pompe", ShotSpawnP.position,
					new Quaternion(ShotSpawnP.rotation.x, ShotSpawnP.rotation.y, ShotSpawnP.rotation.z + 0.1f, ShotSpawnP.rotation.w), 0);
				PhotonNetwork.Instantiate("pompe", ShotSpawnP.position,
					new Quaternion(ShotSpawnP.rotation.x - 0.1f, ShotSpawnP.rotation.y, ShotSpawnP.rotation.z, ShotSpawnP.rotation.w), 0);
				PhotonNetwork.Instantiate("pompe", ShotSpawnP.position,
					new Quaternion(ShotSpawnP.rotation.x, ShotSpawnP.rotation.y - 0.1f, ShotSpawnP.rotation.z, ShotSpawnP.rotation.w), 0);
				PhotonNetwork.Instantiate("pompe", ShotSpawnP.position,
					new Quaternion(ShotSpawnP.rotation.x, ShotSpawnP.rotation.y, ShotSpawnP.rotation.z - 0.1f, ShotSpawnP.rotation.w), 0);

				currentChargeurPompe -= 1;

				nextFire = Time.time + fireRate;
			}

		}
	}

	public static bool Isgun
	{
		get { return isgun; }
		set { isgun = value; }
	}
[PunRPC]
	public void ActiveArme(string s, bool p)
	{
		if(s == "pistolet")
			deagle.SetActive(p);
		if(s == "assaut")
			M4.SetActive(p);
		if(s == "pompe")
			M807.SetActive(p);
	}
}
