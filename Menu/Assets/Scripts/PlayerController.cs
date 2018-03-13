using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	private Camera cam;
	public LayerMask mask;
	private PlayerMotor motor;
	public Text hp;
	public Text cons;
	private int life = 100;
	private int maxlife = 100;
	public Slider hpslider;
	public GameObject deadText;
	public GameObject porte;
	public string[] inventaire;

	void Start()
	{
		cam = Camera.main;
		motor = GetComponent<PlayerMotor>();
		hp.text = life + " / " + maxlife;
		inventaire = new string[10];
		for (int i = 0; i < 10; i++)
		{
			inventaire[i] = "";
		}
	}

	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Ray ray = cam.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, mask))
			{
				motor.MoveToPoint(hit.point);
			}
		}
		if (Input.GetKeyDown(KeyCode.L))
		{
			if (life - 15 > 0)
				life -= 15;
			else
			{
				life = 0;
				deadText.SetActive(true);
			}

		}
		if (Input.GetKeyDown(KeyCode.M))
		{
			if (life + 20 < maxlife)
				life += 20;
			else
			{
				life = maxlife;
			}

		}

		hp.text = life + " / " + maxlife;
		hpslider.value = (float) life / maxlife;

	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "key")
		{
			cons.text = "Appuyer sur F pour rammasser la clé " + other.name + ".";
		}

	}
	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "key")
		{
			cons.text = "";
		}

	}

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "key" && Input.GetKeyDown(KeyCode.F))
		{
			inventaire[0] = other.name;
			other.gameObject.SetActive(false);
			cons.text = "Tu as ramassé la clé " + inventaire[0];
			
		}

	}
}