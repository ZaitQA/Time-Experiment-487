using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : PlayerStat
{

	private static bool attacked;
	private float timer;
	public float couldownTime;
	
	void Update ()
	{
		couldownTime = GetComponent<PlayerStat>().TimeBetweenAttack;
		timer += Time.deltaTime;
		Debug.Log(timer);
		attack = GetComponent<PlayerStat>().attack;
		if (Input.GetMouseButtonDown(1) && timer >= couldownTime)
		{
			attacked = true;
			timer = 0;
		}
	}
	public static bool Attacked
	{
		get { return attacked; }
		set { attacked = value; }
	}
}
