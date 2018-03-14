using System.Collections;
using System.Collections.Generic;
using System.Timers;
using NUnit.Framework;
using TMPro;
using UnityEditor;
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
	
	void Start ()
	{
		
		this.Speed2 = GetComponent<NavMeshAgent>().speed;
		this.Accelerate2 =  GetComponent<NavMeshAgent>().acceleration;
	}
	
	public float TimerA;
	public float TimerS;
	public float TimerT;
	
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
			TimerT = 5.0f;
		}
		if (Input.GetKey(KeyCode.Keypad2))
		{
			Accelerate = true;
			TimerA = 5.0f;
		}
		
		if (Input.GetKey(KeyCode.Keypad3))
		{
			stune = true;
			TimerS = 5.0f;
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
			if (TimerT > 0)
			{
				GetComponent<NavMeshAgent>().speed = 5000;
				GetComponent<NavMeshAgent>().acceleration = 10000;

			}
			if (TimerT <= 0)
			{
				Teleport = false;
				GetComponent<NavMeshAgent>().speed = Speed2;
				GetComponent<NavMeshAgent>().acceleration = Accelerate2;

			}
			TimerT -= Time.deltaTime;
			
		}
	}

	public static bool Stune
	{
		get { return stune; }
		set { stune = value; }
	}
}
