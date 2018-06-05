using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
	private NavMeshAgent agent;

	// Use this for initialization
	void Start ()
	{

		agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	public void MoveToPoint(Vector3 point)
	{
	 
		PhotonView.Get(this).RPC("PlayerMove", PhotonPlayer.Find(1), point);
		PhotonView.Get(this).RPC("PlayerMove", PhotonPlayer.Find(2), point);
	}

	[PunRPC]
	public void PlayerMove(Vector3 p)
	{
		agent.SetDestination(p);
	}
}