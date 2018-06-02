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
	}

	
}
