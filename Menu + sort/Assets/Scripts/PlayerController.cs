using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	
	public Camera cam; 
	public LayerMask mask;
	public MotorMovement motor;
	public Text hp;
	private int life = 100;
	private int maxlife = 100;
	public Slider hpslider;
	public GameObject deadText;
	
	void Start ()
	{
		cam = Camera.main;
		motor = GetComponent<MotorMovement>();
		hp.text = life + " / " + maxlife;
	}
	
	void Update ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = cam.ScreenPointToRay((Input.mousePosition));
			RaycastHit hit;

			if (Physics.Raycast(ray, out hit, 100, mask))
			{
				
				motor.MoveToPoint(hit.point);
			}
		}
		if (Input.GetKeyDown(KeyCode.L))
		{
			if(life - 15 > 0)
				life -= 15;
			else
			{
				life = 0;
				deadText.SetActive(true);
			}
			
		}
		if (Input.GetKeyDown(KeyCode.M))
		{
			if(life + 20 < maxlife)
				life += 20;
			else
			{
				life = maxlife;
			}
			
		}

		hp.text = life + " / " + maxlife;
		hpslider.value = (float)life / maxlife;
		
	}

	
}
