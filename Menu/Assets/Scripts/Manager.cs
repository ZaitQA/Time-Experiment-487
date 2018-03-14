﻿﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{


	void Start()
	{
		PhotonNetwork.ConnectUsingSettings("0.1");
		PhotonNetwork.offlineMode = false;
	}


	void Update()
	{
		
	}

	 void OnJoinedLobby()
	{
		Debug.Log("Joined Lobby");
		PhotonNetwork.JoinRandomRoom();
	}

	void OnJoinedRoom()
	{
		Vector3 pos = new Vector3(105, 0, 105);
		Debug.Log("Joined room");
		GameObject j = PhotonNetwork.Instantiate("Player", pos, Quaternion.identity, 0);
		j.GetComponent<PlayerController>().enabled = true;
		j.GetComponent<PlayerMotor>().enabled = true;
		j.GetComponent<SpellController>().enabled = true;


	}
	
	void OnPhotonRandomJoinFailed()
	{
		Debug.Log("Random join Failed");
		PhotonNetwork.CreateRoom("Room");
	}

	
	
}