using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMovement : MonoBehaviour
{
	private Transform player;               // Reference to the player's position.
	//PlayerHealth playerHealth;      // Reference to the player's health.
	//EnemyHealth enemyHealth;        // Reference to this enemy's health.
	private NavMeshAgent agent;               // Reference to the nav mesh agent.


	void Start()
	{
		// Set up the references.

		//playerHealth = player.GetComponent <PlayerHealth> ();
		//enemyHealth = GetComponent <EnemyHealth> ();
	}


	void Update()
	{
		// If the enemy and the player have health left...
		agent = GetComponent <UnityEngine.AI.NavMeshAgent> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		if(true //enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0
			)
		{
			// ... set the destination of the nav mesh agent to the player.
			float distance = Vector3.Distance(transform.position, player.position);
			if(distance < 30)
				agent.SetDestination (player.position);
		}
		// Otherwise...
		//else
		{
			// ... disable the nav mesh agent.
			//agent.enabled = false;
		}
	} 
}