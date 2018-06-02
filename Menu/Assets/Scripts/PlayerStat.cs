using System;
using System.IO;
using System.Net.Security;
using UnityEngine;


public class PlayerStat : MonoBehaviour
{
	public float attack;
	public float defence;
	public float TimerS;
	public float Life;
	public float TimerA;
	public float TimerP;
	public float speed1;
	public int Nbteleport;
	public float energieV;
	public float defenceS;
	public int Protectiondd;
	public float TimeBetweenAttack;
	public int NbrCOmpétence;

	private float attackadd;
	private float defenceadd;
	private float TimerSadd;
	private float lifeadd;
	private float TimerAadd;
	private float speedadd;
	private int Nbteleportadd;
	private float energieadd;


	 void Start()
	{
	    speed1 = PlayerPrefs.GetInt("speed") + 16f;
		TimerA = PlayerPrefs.GetInt("accelerate") + 3f;
		TimerS = PlayerPrefs.GetInt("Stune") + 5f;
		TimerP = PlayerPrefs.GetInt("TimerP");
		attack =  PlayerPrefs.GetInt("attack") + 10f;
		defence += PlayerPrefs.GetInt("defence") + 0f;
		defenceS += PlayerPrefs.GetInt("defenceS") + 0f;
		Life = PlayerPrefs.GetInt("life") + 100;
		energieV = PlayerPrefs.GetInt("energie") + 100;
		Nbteleport = PlayerPrefs.GetInt("Nbteleport") + 1;
		TimeBetweenAttack = 2;
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
		GetComponent<PlayerStat>().Life = Life;
		GetComponent<PlayerStat>().speed1 = speed1;
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

	}

public void Defenceadd()
{
	if (NbrCOmpétence >= 1)
	{
		PlayerPrefs.SetInt("defence", 5);
		Debug.Log(5);
		NbrCOmpétence -= 1;
	}
}
public void Accelerationadd()
{
	
		if (NbrCOmpétence >= 1)
		{
			PlayerPrefs.SetInt("accelerate", 2);
			PlayerPrefs.SetInt("speed", 2);
			NbrCOmpétence -= 1;
		}

	}

public void Lifeadd()
{
		if (NbrCOmpétence >= 1)
		{
			PlayerPrefs.SetInt("life", 20);
			NbrCOmpétence -= 1;
		}

}


public void Telportadd()
{
		if (NbrCOmpétence >= 1)
		{
			PlayerPrefs.SetInt("Nbteleport", 1);
			NbrCOmpétence -= 1;
		}

	}


public void EnergieAdd()
{
	
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


}
