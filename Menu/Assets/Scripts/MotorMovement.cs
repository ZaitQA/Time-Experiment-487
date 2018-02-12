using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MotorMovement : MonoBehaviour
{
	private NavMeshAgent agent;
	
	void Start ()
	{
		agent = GetComponent<NavMeshAgent>();
	}
	
	public void MoveToPoint (Vector3 point)
	{
		agent.SetDestination(point);
	}
}
