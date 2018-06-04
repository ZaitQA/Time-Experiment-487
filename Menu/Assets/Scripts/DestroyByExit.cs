using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByExit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "shot")
		{
			Destroy(other.gameObject);
		}
	}
}
