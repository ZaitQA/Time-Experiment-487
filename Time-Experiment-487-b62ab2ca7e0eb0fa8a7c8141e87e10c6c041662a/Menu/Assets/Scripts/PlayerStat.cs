using System;
using System.IO;
using UnityEngine;


public class PlayerStat : MonoBehaviour
{
	private TextReader _reader;
	public float attack;
	public float defence;
	public float TimerS;
	public float Life;
	public float TimerA;
	public float speed;
	public int Nbteleport;
	public float energieV;
	public int NbrCOmpétence;
	
	void Start ()
	{
		speed = speedadd + 16f;
		TimerA = TimerAadd + 3f;
		TimerS = TimerSadd + 5f;
		attack =  Attack + 1f;
		Debug.Log(Attack);
		defence = defenceadd + 0f;
		Life = lifeadd + 100;
		energieV = energieadd + 100;
		Nbteleport = Nbteleportadd + 1;
		NbrCOmpétence = 1;
	}
	
	private float attackadd;
	private float defenceadd;
	private float TimerSadd;
	private float lifeadd;
	private float TimerAadd;
	private float speedadd;
	private int Nbteleportadd;
	private float energieadd;

	
	void Update ()
	{
		GetComponent<PlayerStat>().speed = speed;
		GetComponent<PlayerStat>().TimerA = TimerA;
		GetComponent<PlayerStat>().TimerS = TimerS;
		GetComponent<PlayerStat>().attack = attack;
		GetComponent<PlayerStat>().defence = defence;
		GetComponent<PlayerStat>().Nbteleport = Nbteleport;
	}

	public void Stuneadd()
	{
		if (NbrCOmpétence >= 1)
		{
			TimerSadd += 2.0f;
			NbrCOmpétence -= 1;
		}
	}
	public void Attackadd()
	{
		if (NbrCOmpétence >= 1)
		{
			attackadd += 1;
			NbrCOmpétence -= 1;
		}
	}
	public void Defenceadd()
	{
		if (NbrCOmpétence >= 1)
		   {
			defenceadd += 1;
			NbrCOmpétence -= 1;
	       }
	}
	public void Accelerationadd()
	{
		if (NbrCOmpétence >= 1)
		{
			TimerAadd += 2.0f;
			speedadd += 2f;
			NbrCOmpétence -= 1;
		}
	}
	public void Lifeadd()
	{
		if (NbrCOmpétence >= 1)
		{
			lifeadd += 10;
			NbrCOmpétence -= 1;
		}
	}
	
	public void Telportadd()
	{
		if (NbrCOmpétence >= 1)
		{
			Nbteleportadd += 1;
			NbrCOmpétence -= 1;
		}
	}

	public void EnergieAdd()
	{
		if (NbrCOmpétence >= 1)
		{
			energieadd += 10;
			NbrCOmpétence -= 1;
		}
	}
	public float Attack
	{
		get { return attackadd; }
	}

}
