using System;
using System.IO;
using System.Net.Security;
using UnityEngine;


public class PlayerStat : MonoBehaviour
{
	private TextReader _reader;
	public float attack;
	public float defence;
	public float TimerS;
	public float Life;
	public float TimerA;
	public float TimerP;
	public float speed;
	public int Nbteleport;
	public float energieV;
	public float defenceS;
	public int Protectiondd;
	public int NbrCOmpétence;

	void Start()
	{
<<<<<<< HEAD
		attackadd = GetComponent<PlayerStat>().attackadd;
		speed = speedadd + 16f;
		TimerA = TimerAadd + 3f;
		TimerS = TimerSadd + 5f;
		//attack = Attackadd1 + 1f;
		defence = defenceadd + 0f;
		Life = lifeadd + 100;
		energie = energieadd + 100;
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
}

/*void Update ()
{
	GetComponent<PlayerStat>().speed = speed;
	GetComponent<PlayerStat>().TimerA = TimerA;
	GetComponent<PlayerStat>().TimerS = TimerS;
	GetComponent<PlayerStat>().attack = attack;
	GetComponent<PlayerStat>().defence = defence;
	GetComponent<PlayerController>().life = Life;
	GetComponent<PlayerController>().energieV = energie;
	GetComponent<PlayerStat>().Nbteleport = Nbteleport;
}

public void Stuneadd()
{
	if (NbrCOmpétence >= 1)
	{
		TimerSadd += 2.0f;
		NbrCOmpétence -= 1;
=======
		speed = PlayerPrefs.GetInt("speed") + 16f;
		TimerA = PlayerPrefs.GetInt("accelerate") + 3f;
		TimerS = PlayerPrefs.GetInt("Stune") + 5f;
		TimerP = PlayerPrefs.GetInt("TimerP");
		attack =  PlayerPrefs.GetInt("attack") + 10f;
		defence += PlayerPrefs.GetInt("defence") + 0f;
		defenceS += PlayerPrefs.GetInt("defenceS") + 0f;
		Life = PlayerPrefs.GetInt("life") + 100;
		energieV = PlayerPrefs.GetInt("energie") + 100;
		Nbteleport = PlayerPrefs.GetInt("Nbteleport") + 1;
		Protectiondd = PlayerPrefs.GetInt("Protection");
		
		PlayerPrefs.DeleteKey("speed");
		PlayerPrefs.DeleteKey("accelerate");
		PlayerPrefs.DeleteKey("Stune");
		PlayerPrefs.DeleteKey("TimerP");
		PlayerPrefs.DeleteKey("attack");
		PlayerPrefs.DeleteKey("defence");
		PlayerPrefs.DeleteKey("life");
		PlayerPrefs.DeleteKey("energie");
		PlayerPrefs.DeleteKey("Nbteleport");
		
		NbrCOmpétence = 2;
	}
	
	void Update ()
	{
		GetComponent<PlayerStat>().speed = speed;
		GetComponent<PlayerStat>().TimerA = TimerA;
		GetComponent<PlayerStat>().TimerS = TimerS;
		GetComponent<PlayerStat>().TimerP = TimerP;
		GetComponent<PlayerStat>().defenceS = defenceS;
		GetComponent<PlayerStat>().Protectiondd = Protectiondd;
		GetComponent<PlayerStat>().attack = attack;
		GetComponent<PlayerStat>().defence = defence;
		GetComponent<PlayerStat>().Nbteleport = Nbteleport;
	}

	public void Stuneadd()
	{
		if (NbrCOmpétence >= 1)
		{
			PlayerPrefs.SetInt("Stune", 2);
			NbrCOmpétence -= 1;
		}
	}
	public void Attackadd()
	{
		if (NbrCOmpétence >= 1)
		{
			PlayerPrefs.SetInt("attack", 5);
			NbrCOmpétence -= 1;
		}
>>>>>>> 06fdd92dd44637171bc628f742c674bad345a3db
	}
}
public void Attackadd()
{
	if (NbrCOmpétence >= 1)
	{
<<<<<<< HEAD
		attackadd = PlayerPrefs.GetInt("Attack", 0);
		NbrCOmpétence -= 1;
=======
		if (NbrCOmpétence >= 1)
		   {
			PlayerPrefs.SetInt("defence", 5);
			Debug.Log(5);
			NbrCOmpétence -= 1;
	       }
>>>>>>> 06fdd92dd44637171bc628f742c674bad345a3db
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
<<<<<<< HEAD
		TimerAadd += 2.0f;
		speedadd += 2f;
		NbrCOmpétence -= 1;
=======
		if (NbrCOmpétence >= 1)
		{
			PlayerPrefs.SetInt("accelerate", 2);
			PlayerPrefs.SetInt("speed", 2);
			NbrCOmpétence -= 1;
		}
>>>>>>> 06fdd92dd44637171bc628f742c674bad345a3db
	}
}
public void Lifeadd()
{
	if (NbrCOmpétence >= 1)
	{
<<<<<<< HEAD
		lifeadd += 10;
		NbrCOmpétence -= 1;
=======
		if (NbrCOmpétence >= 1)
		{
			PlayerPrefs.SetInt("life", 20);
			NbrCOmpétence -= 1;
		}
>>>>>>> 06fdd92dd44637171bc628f742c674bad345a3db
	}
}

public void Telportadd()
{
	if (NbrCOmpétence >= 1)
	{
<<<<<<< HEAD
		Nbteleportadd += 1;
		NbrCOmpétence -= 1;
=======
		if (NbrCOmpétence >= 1)
		{
			PlayerPrefs.SetInt("Nbteleport", 1);
			NbrCOmpétence -= 1;
		}
>>>>>>> 06fdd92dd44637171bc628f742c674bad345a3db
	}
}

public void EnergieAdd()
{
	if (NbrCOmpétence >= 1)
	{
<<<<<<< HEAD
		energieadd += 10;
		NbrCOmpétence -= 1;
	}
=======
		if (NbrCOmpétence >= 1)
		{
			PlayerPrefs.SetInt("energie", 10);
			NbrCOmpétence -= 1;
		}
	}

	public void ProtectionSpell()
	{
		if (NbrCOmpétence >= 2)
		{
			PlayerPrefs.SetInt("TimerP", 3);
			PlayerPrefs.SetInt("defenceS", 15);
			PlayerPrefs.SetInt("Protection", 1);
			NbrCOmpétence -= 2;
		}
	}
>>>>>>> 06fdd92dd44637171bc628f742c674bad345a3db
}
public float Attackadd1
{
	get { return attackadd; }
	set { attackadd = value; }
}	
}*/
