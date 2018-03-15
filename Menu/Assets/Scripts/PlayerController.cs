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

	private GameObject HP;
	public Text hp;
	
	public GameObject cons;

	public Text consT;
	private int life = 100;

	private int maxlife = 100;

	private GameObject HPslider;
	public Slider hpslider;
	
	public GameObject deadText;
	private Text dead;
	
	private string[] inventaire = new string[10];

	private GameObject m;

	private float timer = 0;
	//private int nbPlayer;

	void Start()
	{

		Vector3 pos = new Vector3(105, 0, 105);
		GameObject c = PhotonNetwork.Instantiate("Main Camera", pos, Quaternion.identity, 0);



		m = PhotonNetwork.Instantiate("Canvas", pos, Quaternion.identity, 0);
		m.SetActive(true);
		
		hpslider = GameObject.Find("Slider").GetComponent<Slider>();
		consT = GameObject.Find("cons").GetComponent<Text>();
		hp = GameObject.Find("hp").GetComponent<Text>();
		/*HPslider = PhotonNetwork.Instantiate("Slider", new Vector3(250, 50, 0), Quaternion.identity, 0);
		HPslider.transform.SetParent(m.transform, false);
		hpslider = HPslider.GetComponent<Slider>();
		
		cons = PhotonNetwork.Instantiate("cons", pos, Quaternion.identity, 0);
		cons.transform.SetParent(m.transform, false);
		consT = cons.GetComponent<Text>();*/
		
		deadText = PhotonNetwork.Instantiate("Dead", pos, Quaternion.identity, 0);
		deadText.transform.SetParent(m.transform, false);
		dead = deadText.GetComponent<Text>();
		
		/*HP = PhotonNetwork.Instantiate("hp", new Vector3(250, 50, 0), Quaternion.identity, 0);
		HP.transform.SetParent(m.transform, false);
		hp = HP.GetComponent<Text>();*/
		
		c.GetComponent<Camera>().enabled = true;
		c.GetComponent<AudioListener>().enabled = true;
		c.GetComponent<CameraController>().enabled = true;
		c.GetComponent<CameraController>().target = this.transform;
		cam = c.GetComponent<Camera>();
		motor = GetComponent<PlayerMotor>();
		hp.text = life + " / " + maxlife;
	}

	void Update()
	{

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			m.GetComponent<MENU>().ResumeBut();
		}﻿
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
		
		if (life >= maxlife)
		{
			life = maxlife;
		}
		else if (life <= 0)
		{
			life = 0;
			Dead();
		}

		hp.text = life + " / " + maxlife;
		hpslider.value = (float) life / maxlife;

	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "key" && consT != null)
		{

			consT.text = "Appuyer sur F pour rammasser la clé " + other.name;
		}
		

	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "key" && consT != null)
		{
			consT.text = "";
		}

	}

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "key" && Input.GetKeyDown(KeyCode.F) && consT != null)
		{
			if (inventaire.Length >= 1)
				inventaire[0] = other.name;
			other.gameObject.SetActive(false);
			consT.text = "Tu as ramassé la clé " + inventaire[0];

		}
		if (other.tag == "fire")
		{
			timer += Time.deltaTime;
			if (timer >= 0.5)
			{
				timer = 0;
				life -= 1;
			}
		}

	}

	private void Dead()
	{
		deadText.SetActive(true);
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;
		Time.timeScale = 0;
	}
	
	public string[] Inventaire
	{
		get { return inventaire; }
	}
}