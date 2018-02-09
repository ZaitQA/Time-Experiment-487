using System.Collections;
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
		Debug.Log("Joined room");
		GameObject j = PhotonNetwork.Instantiate("Sphere", Vector3.up * 5, Quaternion.identity, 0);
		j.GetComponent<PlayerController>().enabled = true;

	}
	
	void OnPhotonRandomJoinFailed()
	{
		Debug.Log("Random join Failed");
		PhotonNetwork.CreateRoom("Room");
	}

	
	
}
