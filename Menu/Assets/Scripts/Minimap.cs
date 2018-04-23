using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.VR.WSA;

public class Minimap : MonoBehaviour {

	// Use this for initialization
	public Transform playert;

	public GameObject Player;
	void Start ()
	{
		playert = GameObject.Find("Player1").transform;
	}
	
	// Update is called once per frame
	void Update ()
	{
		while(playert == null)
			playert = GameObject.Find("Player1").transform;
		
		Vector3 newPos = playert.position;
		newPos.y = transform.position.y;
		transform.position = newPos;
	}
}
