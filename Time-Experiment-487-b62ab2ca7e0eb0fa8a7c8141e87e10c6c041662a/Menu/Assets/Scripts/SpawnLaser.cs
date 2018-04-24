using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLaser : MonoBehaviour
{

	public GameObject laser;

	public float timer;
	public bool last;

	public int sec;

	public float init;

	public float trans;

	private bool deux;

	private bool quatre;
	
	// Use this for initialization
	void Start ()
	{
		timer = 0;
		sec = 0;
		init = laser.transform.position.z;
		trans = laser.transform.position.z + 8;
		deux = false;
		quatre = false;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= 1)
		{
			sec += 1;
			timer = 0;
		}
		if (sec == 2 && !deux)
		{
			deux = true;
			if (last)
			{
				laser.transform.position = new Vector3(laser.transform.position.x, laser.transform.position.y, trans);
				last = !last;

			}
			else
			{
				laser.transform.position = new Vector3(laser.transform.position.x, laser.transform.position.y, init);
				last = !last;
			}
		}
		if (sec == 4 && !quatre)
		{
			quatre = true;
			if (!last)
			{
				laser.transform.position = new Vector3(laser.transform.position.x, laser.transform.position.y, init);
				last = !last;
			}
			else
			{
				laser.transform.position = new Vector3(laser.transform.position.x, laser.transform.position.y, trans);
				last = !last;
			}
		}
		if (sec == 5)
		{
			deux = false;
			quatre = false;
			sec = 0;
		}
	}
}
