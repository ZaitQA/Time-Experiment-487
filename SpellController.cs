using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class SpellController : PlayerStat
{
	
	private static bool stune;
	private static bool Teleport;
	private static bool Accelerate;
	private static bool Protection;
	private float defence2;
	private float Speed2; 
	private float Accelerate2;
	public int count = 0;
	private float dis;
	private GameObject j;
	private GameObject p;
	private Camera cam1;
	public bool run;
	
	void Start ()
	{
		Nbteleport = GetComponent<PlayerStat>().Nbteleport;
		this.Speed2 = GetComponent<NavMeshAgent>().speed;
		this.Accelerate2 =  GetComponent<NavMeshAgent>().acceleration;
		this.defence2 = GetComponent<PlayerStat>().defence;
	}
	
	
	void Update () 
	
	{
		if (Teleport)
        {FuncTeleport();}
		
		if (Accelerate)
		{FuncAccelerate();}
		
		if (Stune)
		{FuncStune();}
		
		if (Protection)
		{FuncProtection();}
			
		if (Input.GetKeyDown(KeyCode.Keypad1))
		{
			if (GetComponent<PlayerController>().energieV >= 20)
			{
				Teleport = true;
				Nbteleport = GetComponent<PlayerStat>().Nbteleport;
				GetComponent<PlayerController>().energieV  -= 20;
			}
			else
			{
				
				GetComponent<PlayerController>().consT.text = "No more energie";
			}

		}
		if (Input.GetKeyDown(KeyCode.Keypad2))
		{
			if (GetComponent<PlayerController>().energieV >= 15)
			{
				Accelerate = true;
				speed1 = GetComponent<PlayerStat>().speed1;
				TimerA = GetComponent<PlayerStat>().TimerA;
				GetComponent<PlayerController>().energieV -= 15;
			}
			else
			{
				GetComponent<PlayerController>().consT.text = "No more energie";
			}
		}
		
		if (Input.GetKeyDown(KeyCode.Keypad3))
		{
			if (GetComponent<PlayerController>().energieV >= 25)
			{
				stune = true;
				TimerS = GetComponent<PlayerStat>().TimerS;
				GetComponent<PlayerController>().energieV -= 25;
			}
			else
			{
				GetComponent<PlayerController>().consT.text = "No more energie";
			}
		}
		if (Input.GetKeyDown(KeyCode.Keypad4))
		{
			Debug.Log("1");
			if (PlayerPrefs.GetInt("Proctection") == 1)
			{
				if (GetComponent<PlayerController>().energieV >= 25)
				{
					Protection = true;
					TimerP = GetComponent<PlayerStat>().TimerP;
					spellDefence = GetComponent<PlayerStat>().spellDefence;
					GetComponent<PlayerController>().energieV -= 25;
				}
			}
				
		}
	}
	
	public void FuncAccelerate()
		{
			if (Accelerate)
			{
				if (TimerA > 0)
				{
					run = true;
					GetComponent<NavMeshAgent>().speed = speed1;
				}

				if (TimerA <= 0)
				{

					run = false;
					Accelerate = false;
					GetComponent<NavMeshAgent>().speed = Speed2;
				}
				TimerA  -= Time.deltaTime;
				
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
					if (dis < 20)
					{
						GetComponent<NavMeshAgent>().speed = 5000;
						GetComponent<NavMeshAgent>().acceleration = 10000;
						count += 1;
					}
					if (dis > 20)
					{
						GetComponent<PlayerController>().consT.text = "To far";
					}
				}
			}
			if (count > Nbteleport)
			{
				count = 0;
			    Teleport = false;
			}
		
		if (Teleport == false)
		{
			GetComponent<NavMeshAgent>().speed = Speed2;
			GetComponent<NavMeshAgent>().acceleration = Accelerate2;
		}
	}

	public void FuncProtection()
	{
		if (Protection)
		{
			if (TimerP > 0)
			{
				GetComponent<PlayerStat>().defence = spellDefence;
			}
			if(TimerP <= 0)
			{
				Protection = false;
				GetComponent<PlayerStat>().defence = defence2;
			}
			TimerP -= Time.deltaTime;
		}
	}
	

	public static bool Stune
	{
		get { return stune; }
		set { stune = value; }
	}
	public static bool protection
	{
		get { return Protection; }
		set { Protection = value; }
	}
}
