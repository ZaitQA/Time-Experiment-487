using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tourelle : MonoBehaviour
{
	private GameObject player;
	
	public float health;
	public float healthmax;
	public float attack;
	public float fireRate;
	public float nextFire = 0f;
	public GameObject shot;
	public Transform ShotSpawn;
	public Transform ShotSpawn1;
	public Slider healthSlide;

	public float dismax;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update ()
	{
		healthSlide.value = health / healthmax;
		player = GameObject.FindGameObjectWithTag ("Player");
		if (health > 0)
		{
			if (health > 0 && Vector3.Distance(player.transform.position, transform.position) < dismax)
			{
				transform.LookAt(player.transform.position);
				transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);

				if (Time.time > nextFire)
				{
					ShotSpawn.LookAt(player.transform.position);
					ShotSpawn1.LookAt(player.transform.position);
					Instantiate(shot, ShotSpawn.position, ShotSpawn.rotation);
					Instantiate(shot, ShotSpawn1.position, ShotSpawn1.rotation);
					nextFire = Time.time + fireRate;
				}

			}
		}
		else
			healthSlide.gameObject.SetActive(false);


	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "shot")
		{
			health -= 25;
		}
	}
}
