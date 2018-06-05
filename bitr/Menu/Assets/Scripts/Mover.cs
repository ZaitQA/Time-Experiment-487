using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

	private Rigidbody rb;
	public int speed;

	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.forward * speed;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "wall")
		{
			Destroy(gameObject);
		}
		if (other.tag == "Player")
		{
			other.GetComponent<PlayerController>().Life -= 5;
		}
		if (other.tag == "Tourelle")
		{
			other.GetComponent<Tourelle>().health -= 15;
			Destroy(gameObject);
		}
	}

	
}
