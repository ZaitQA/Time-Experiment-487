using System.Collections;
using System.Collections.Generic;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class SpellController : PlayerController
{
	private static bool stune;
	private static bool Teleport;
	private static bool Accelerate;
	private float Speed2; 
	private float Accelerate2;
	public int count = 0;
	private float dis;
	private GameObject j;
	private GameObject p;
	private Camera cam1;
	
	void Start ()
	{
		
		this.Speed2 = GetComponent<NavMeshAgent>().speed;
		this.Accelerate2 =  GetComponent<NavMeshAgent>().acceleration;
	}
	
	public float TimerA;
	public float TimerS;
	
	
	void Update () 
	
	{
		if (Teleport)
        {
			FuncTeleport();
		}
		if (Accelerate)
		{
			FuncAccelerate();
		}
		if (Stune)
		{
			FuncStune();
		}
			
		if (Input.GetKey(KeyCode.Keypad1))
		{
			Teleport = true;
			energieV -= 20;

		}
		if (Input.GetKey(KeyCode.Keypad2))
		{
			Accelerate = true;
			TimerA = 5.0f;
			energieV -= 15;
		}
		
		if (Input.GetKey(KeyCode.Keypad3))
		{
			stune = true;
			TimerS = 5.0f;
			energieV -= 25;
		}
	}
	
	public void FuncAccelerate()
		{
			if (Accelerate)
			{
				if (TimerA > 0)
				{
					GetComponent<NavMeshAgent>().speed = 16;
				}

				if (TimerA <= 0)
				{
					Accelerate = false;
					GetComponent<NavMeshAgent>().speed = Speed2;
				}
				TimerA -= Time.deltaTime;
				
			}
		}
	
	public void FuncStune()
		{
			if (Stune)
			{
				if (TimerS > 0)
				{
					Stune = true;
				}

				if (TimerS <= 0)
				{
					Stune = false;
				}
			}
			TimerS -= Time.deltaTime;
		}

	public void FuncTeleport()
	{
	
		if (Teleport)
		{
			
			if (Input.GetMouseButton(0))
			{
				cam1 = GetComponent<PlayerController>().cam;
				Ray ray = cam1.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit;
				if (Physics.Raycast(ray, out hit))
				{
					dis = Vector3.Distance(hit.point, transform.position);
					
				}
				if (dis < 10)
				{
					GetComponent<NavMeshAgent>().speed = 5000;
					GetComponent<NavMeshAgent>().acceleration = 10000;
					count += 1;
				}
				
			}
			if (count > 1)
			{
				Teleport = false;
			}
			
		}
		if (Teleport == false)
		{
			count = 0;
			GetComponent<NavMeshAgent>().speed = Speed2;
			GetComponent<NavMeshAgent>().acceleration = Accelerate2;
		}
	}

	public static bool Stune
	{
		get { return stune; }
		set { stune = value; }
	}
}
