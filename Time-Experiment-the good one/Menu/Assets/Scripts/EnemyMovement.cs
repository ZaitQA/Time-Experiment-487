﻿using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
	private GameObject player;               // Reference to the player's position.
	PlayerController playerHealth;      // Reference to the player's health.
	EnemyHealth enemyHealth;        // Reference to this enemy's health.
	private NavMeshAgent agent;               // Reference to the nav mesh agent.


	void Update()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent <PlayerController> ();
		enemyHealth = GetComponent <EnemyHealth> ();
		agent = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		if(enemyHealth.currentHealth > 0 && playerHealth.Life > 0 )
		{
			float distance = Vector3.Distance(transform.position, player.transform.position);
			if(distance < 8 && SpellController.Stune == false)
			PhotonView.Get(this).RPC("enemmymov", PhotonTargets.All);
		}
		// Otherwise...
		else
		{
			agent.enabled = false;
		}
	}

	[PunRPC]
	private void enemmymov()
	{
		
		{agent.SetDestination (player.transform.position);}
	}
}