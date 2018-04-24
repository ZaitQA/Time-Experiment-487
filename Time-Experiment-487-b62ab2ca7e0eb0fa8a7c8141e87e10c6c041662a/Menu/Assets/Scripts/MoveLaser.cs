using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  MoveLaser : MonoBehaviour {

	public Transform laser;

	private float maxLaser;
	private float minLaser;
	private float move;
	public float speed;
	public bool top;
	private bool returni;
	public bool op;

	void Start()
	{
		if (op && !top)
		{
			minLaser = laser.position.z - 7;
			maxLaser = laser.position.z;
			returni = true;
		}
		else if(!op && !top)
		{
			minLaser = laser.position.z;
			maxLaser = laser.position.z + 7;
			returni = false;
		}
		else if (op && top)
		{
			minLaser = laser.position.y - 6;
			maxLaser = laser.position.y;
			returni = true;
		}
		else
		{
			minLaser = laser.position.y;
			maxLaser = laser.position.y + 6;
			returni = false;
		}
	}

	// Update is called once per frame
	void Update()
	{
		if(!top)
			MoveLaserH();
		else
		{
			MoveLaserT();
		}

	}

	public void MoveLaserH()
	{
		if (laser.position.z < minLaser)
		{
			returni = false;
		}
		if (laser.position.z > maxLaser)
		{
			returni = true;
		}
		if (!returni)
		{
			move = 0.5f * Time.deltaTime * speed;

			laser.position = new Vector3(
				laser.position.x,
				laser.position.y,
				laser.position.z + move
			);
		}
		else
		{
			move = 0.5f * Time.deltaTime * speed;

			laser.position = new Vector3(
				laser.position.x,
				laser.position.y,
				laser.position.z - move
			);
		}

	}
	public void MoveLaserT()
	{
		if (laser.position.y < minLaser)
		{
			returni = false;
		}
		if (laser.position.y > maxLaser)
		{
			returni = true;
		}
		if (!returni)
		{
			move = 0.5f * Time.deltaTime * speed;

			laser.position = new Vector3(
				laser.position.x,
				laser.position.y + move,
				laser.position.z
			);
		}
		else
		{
			move = 0.5f * Time.deltaTime * speed;

			laser.position = new Vector3(
				laser.position.x,
				laser.position.y - move,
				laser.position.z
			);
		}

	}
}
