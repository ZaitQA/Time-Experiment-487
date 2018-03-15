using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MENU : MonoBehaviour 
{


public GameObject MenuObject;
public bool isActive;
	
	void Update ()
	{
		if (isActive)
		{
			MenuObject.SetActive(true);
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.Confined;
			Time.timeScale = 0;
		}
		else
		{
			MenuObject.SetActive(false);
			Cursor.visible = true;
			Time.timeScale = 1;
		}
	}

	public void ResumeBut()
	{
		isActive = !isActive;
	}
}
