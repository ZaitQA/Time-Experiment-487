﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colorchange : MonoBehaviour
{
	public GameObject Vert;
	public GameObject Red;
	
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
			if (GetComponent<openDoor>().secure)
			{
				Vert.SetActive(false);
				Red.SetActive(true);
			}
			else
			{
				Red.SetActive(false);
				Vert.SetActive(true);
			}
		

	}
}