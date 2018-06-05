using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SwitchArme : MonoBehaviour {

	// Use this for initialization
	public string[] armes;

	public GameObject player;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.Find("Player1");
		
	}

	public void Switch(string arme)
	{
		armes = player.GetComponent<PlayerController>().armes;
		armes[0] = arme;
	}
}
