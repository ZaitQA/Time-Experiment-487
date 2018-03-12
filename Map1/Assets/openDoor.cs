using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour {

	// Use this for initialization
	public Transform door;

	public float speed;
	private float move;
	private bool opening;
	private bool closing;
	private float maxOpen;
	void Start ()
	{
		opening = false;
		closing = false;
		maxOpen = door.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		if(opening)
			OpenDoor();
		if(closing)
			CloseDoor();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			opening = true;
			closing = false;
		}
			
		
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
		{
			opening = false;
			closing = true;
		}
	}

	private void OpenDoor()
	{
		if (door.position.z <= 110 + 4)
		{
			move = 0.5f * Time.deltaTime * speed;
			
			door.position = new Vector3(
				door.position.x,
				door.position.y,
				door.position.z + move
			);
		}
			
	}
	private void CloseDoor()
	{
		if (door.position.z >= 110)
		{
			move = 0.5f * Time.deltaTime * speed;
			
			door.position = new Vector3(
				door.position.x,
				door.position.y,
				door.position.z - move
			);
		}
			
	}
}
