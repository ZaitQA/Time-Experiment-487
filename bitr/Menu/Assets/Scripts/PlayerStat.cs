using System;
using System.IO;
using System.Net.Security;
using UnityEngine;


public class PlayerStat : MonoBehaviour
{
	public float attack = 10;
	public float defence;
	public float TimerS = 5;
	public float Life = 100;
	public float TimerA = 3f;
	public float TimerP = 5;
	public float speed1 = 16;
	public int Nbteleport = 1;
	public float energieV = 100;
	public float spellDefence;
	public float TimeBetweenAttack;
	public int NbrCOmpétence = 1;

	 void Start()
	{
	    speed1 = 16 + PlayerPrefs.GetInt("speed") + PlayerPrefs.GetFloat("SaveSpeed")  ;
		TimerA = 3 +  PlayerPrefs.GetInt("accelerate") + PlayerPrefs.GetFloat("SaveAcc") ;
		TimerS = 5 + PlayerPrefs.GetInt("Stune") + PlayerPrefs.GetFloat("SaveStune") ;
		TimerP = 5 + PlayerPrefs.GetInt("TimerP") + PlayerPrefs.GetFloat("SaveTp") ;
		attack =  10 + PlayerPrefs.GetInt("attack") + PlayerPrefs.GetFloat("SaveAttzck") ;
		defence = PlayerPrefs.GetInt("defence") + PlayerPrefs.GetFloat("SaveDe") ;
		spellDefence = PlayerPrefs.GetInt("Spelldefence") + PlayerPrefs.GetFloat("SaveSD") ;
		Life = 100 + PlayerPrefs.GetInt("life") + PlayerPrefs.GetFloat("LifeS") ;
		energieV = 100 + PlayerPrefs.GetInt("energie") + PlayerPrefs.GetFloat("SaveE") ;
		Nbteleport = 1 + PlayerPrefs.GetInt("Nbteleport") + PlayerPrefs.GetInt("SaveNBT") ;
		
		TimeBetweenAttack = 2;
		
		PlayerPrefs.DeleteKey("speed");
		PlayerPrefs.DeleteKey("accelerate");
		PlayerPrefs.DeleteKey("Stune");
		PlayerPrefs.DeleteKey("TimerP");
		PlayerPrefs.DeleteKey("attack");
		PlayerPrefs.DeleteKey("defence");
		PlayerPrefs.DeleteKey("life");
		PlayerPrefs.DeleteKey("energie");
		PlayerPrefs.DeleteKey("Nbteleport");
		PlayerPrefs.DeleteKey("defenceS");
		
		PlayerPrefs.SetFloat("SaveSpeed", speed1 - 16);
		PlayerPrefs.SetFloat("SaveAcc", TimerA - 3);
		PlayerPrefs.SetFloat("SaveStune", TimerS - 5);
		PlayerPrefs.SetFloat("SaveTp", TimerP - 5);
		PlayerPrefs.SetFloat("SaveAttzck", attack - 10);
		PlayerPrefs.SetFloat("SaveDe", defence - 0);
		PlayerPrefs.SetFloat("SaveSD", spellDefence);
		PlayerPrefs.SetFloat("LifeS", Life - 100) ;
		PlayerPrefs.SetFloat("SaveE", energieV - 100);
		PlayerPrefs.SetInt("SaveNBT", Nbteleport - 1);
		
		NbrCOmpétence = 2;
	}
	
	void Update ()
	{
	}

	public void Stuneadd()
	{
		if (NbrCOmpétence >= 1)
		{
			PlayerPrefs.SetInt("Stune",  5);
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
		PlayerPrefs.SetInt("defence", 5 );
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
			PlayerPrefs.SetInt("Spelldefence",0);
			PlayerPrefs.SetInt("Protection", 1);
			NbrCOmpétence -= 2;
		}
	}

	public void Ressurection()
	{
		if (PlayerPrefs.GetInt("Protection") == 1 && PlayerPrefs.GetInt("Resurection") == 1)
		{
			if (NbrCOmpétence >= 2)
			{
				PlayerPrefs.SetInt("Resurection", 1);
				NbrCOmpétence -= 2;
			}
		}
	}
}
