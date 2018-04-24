using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class openDoor : MonoBehaviour {

	// Use this for initialization
	public Transform door;

	public float speed;
	private float move;
	public bool opening;
	public bool closing;
	public float maxOpenz;
	public float maxOpenx;
	public bool secure;
	public string key;
	private string[] inv;
	private GameObject Player;
	private bool needKey = false;
	public bool cote;
	
	void Start ()
	{
		maxOpenz = door.position.z;
		maxOpenx = door.position.x;
	}
	
	// Update is called once per frame
	private void FixedUpdate()
	{
		if (opening)
		{
			PhotonView.Get(this).RPC("OpenDoor", PhotonTargets.All);
		}
		if(closing)
			PhotonView.Get(this).RPC("CloseDoor", PhotonTargets.All);

	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
			inv = other.GetComponent<PlayerController>().Inventaire;
		if (other.tag == "Player" && tag == "Porte" && !secure || secure && SearchKey(inv, key))
		{
			secure = false;
			opening = true;
			closing = false;
		}
		else if(secure && other.tag == "Player" && other.GetComponent<PlayerController>().consT != null)
		{
			other.GetComponent<PlayerController>().consT.text = "Tu as besoin de " + key;
		}

		
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player" && tag == "Porte" && other.GetComponent<PlayerController>().consT != null)
		{
			opening = false;
			closing = true;
			other.GetComponent<PlayerController>().consT.text = "";
		}
	}

	private bool SearchKey(string[] array, string Key)
	{
		if(array != null)
			for (int i = 0; i < array.Length; i++)
			{
				Debug.Log(array[i] + " " + Key);
				if (array[i] == Key)
					return true;
			}
		return false;
	}
	
	[PunRPC]
	private void OpenDoor()
	{
		
		if (!cote)
		{
			if (door.position.z <= maxOpenz + 4)
			{
				
				move = 0.5f * Time.deltaTime * speed;

				door.position = new Vector3(
					door.position.x,
					door.position.y,
					door.position.z + move
				);
			}
			else opening = false;
		}
		else if (cote)
		{
			if (door.position.x <= maxOpenx + 4)
			{

				move = 0.5f * Time.deltaTime * speed;

				door.position = new Vector3(
					door.position.x + move,
					door.position.y,
					door.position.z
				);
			}
			else opening = false;
		}
	}
	
	[PunRPC]
	private void CloseDoor()
	{
		if(!cote)
		{
			if (door.position.z >= maxOpenz)
		{
			move = 0.5f * Time.deltaTime * speed;

			door.position = new Vector3(
				door.position.x,
				door.position.y,
				door.position.z - move
			);
		}
		else closing = false;
			
		}
		else if (cote)
		{
			if (door.position.x >= maxOpenx)
			{

				move = 0.5f * Time.deltaTime * speed;

				door.position = new Vector3(
					door.position.x - move,
					door.position.y,
					door.position.z
				);
			}
			else opening = false;
		}
	}
	
}
