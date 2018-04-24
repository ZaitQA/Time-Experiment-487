using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class PlayerController : PlayerStat
{
	public Camera cam;
	public LayerMask mask;

	private PlayerMotor motor;

	private GameObject HP;
	public Text hp;
	
	public GameObject cons;

	public Text consT;
	public float life;
	public float energieV;

	private int maxlife = 100;
	private int maxenergie = 100;


	private GameObject miniMap;
	private GameObject vieSlider;
	private GameObject energieSlider;
	public Slider vie;
	public Slider energie;
	
	private GameObject deadText;
	private Text dead;
	
	public string[] inventaire = new string[20];
	public int index = 0;
	private GameObject m;

	private float timer = 0;
	private int nbPlayer;
	private bool deadd;

	void Start()
	{

		life = GetComponent<PlayerStat>().Life;
		energieV = GetComponent<PlayerStat>().energie;
		Debug.Log(nbPlayer);
		nbPlayer = GameObject.Find("Manager").GetComponent<Manager>().nbPlayer;
		Vector3 pos = new Vector3(105, 0, 105);
		GameObject c = PhotonNetwork.Instantiate("Main Camera", pos, Quaternion.identity, 0);
		c.name = "Main Camera" + nbPlayer;

		cam = c.GetComponent<Camera>();


		m = PhotonNetwork.Instantiate("Canvas", pos, Quaternion.identity, 0);
		m.name = "Canvas" + nbPlayer;
		m.SetActive(true);

		miniMap = GameObject.Find("RawImage");
//		miniMap.transform.SetParent(m.transform, false);
		
		consT = GameObject.Find("cons").GetComponent<Text>();
		consT.name = "con" + nbPlayer;

		vieSlider = PhotonNetwork.Instantiate("Vie", new Vector3(250, 50, 0), Quaternion.identity, 0);
		vieSlider.transform.SetParent(m.transform, false);
		vie = vieSlider.GetComponent<Slider>();
		
		energieSlider = PhotonNetwork.Instantiate("Energie", new Vector3(250, 85, 0), Quaternion.identity, 0);
		energieSlider.transform.SetParent(m.transform, false);
		energie = energieSlider.GetComponent<Slider>();

		
		deadText = PhotonNetwork.Instantiate("Dead", pos, Quaternion.identity, 0);
		deadText.transform.SetParent(m.transform, false);
		dead = deadText.GetComponent<Text>();
		deadText.name = "Dead" + nbPlayer;
		
		c.GetComponent<Camera>().enabled = true;
		c.GetComponent<AudioListener>().enabled = true;
		c.GetComponent<CameraController>().enabled = true;
		c.GetComponent<CameraController>().target = transform;
		cam = c.GetComponent<Camera>();
		motor = GetComponent<PlayerMotor>();
	}

	void Update()
	{

		if (deadd)
		{
			deadText.SetActive(true);
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.Confined;
			Time.timeScale = 0;
		}
		else
		{
//			deadText.SetActive(false);
			Cursor.visible = true;
			Time.timeScale = 1;
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				m.GetComponent<MENU>().ResumeBut();
			}
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
				deadd = true;
			}

				vie.value = (float) life / maxlife;
				energie.value = (float) energieV / maxenergie;
			

		}
	}

	private void OnTriggerStay(Collider other)
	{
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



	/*private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "fouille" && tag == "Player" && consT != null)
		{
			consT.text = "Appuyer sur la touche F pour fouiller.";
			Debug.Log("Fouille");

		}
		if (other.tag == "key" && consT != null)
		{
			Debug.Log("Key");
			consT.text = "Appuyez sur la touche R pour ramasser la clé.";
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "fire")
		{
			timer += Time.deltaTime;
			if (timer >= 0.5)
			{
				timer = 0;
				life -= 1;
			}
		}
		if (other.tag == "fouille" && tag == "Player" && other.name == "Rien" && consT != null && Input.GetKeyDown(KeyCode.F))
		{
			consT.text = "Il n'y a rien à l'intérieur ...";
		}
		else if (other.tag == "fouille" && tag == "Player" && other.name != "Rien" && consT != null &&
		         Input.GetKeyDown(KeyCode.F))
		{
			if (inventaire.Length >= 1)
			{
				inventaire[index] = other.name;
				index += 1;
			}
			consT.text = "Tu as trouvé " + other.name;
		}
		else if (other.tag == "key" && Input.GetKeyDown(KeyCode.R) && consT != null)
		{
			if (inventaire.Length >= 1)
			{
				inventaire[index] = other.name;
				index += 1;
			}
			other.gameObject.SetActive(false);
			consT.text = "Tu as ramassé la clé " + other.name;

		}
		

	}

	private void OnTriggerExit(Collider other)
	{
		if ((other.tag == "fouille" || other.tag == "key") && consT != null)
			consT.text = "";
	}*/

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

	public int Index
	{
		get { return index; }
		set { index = value; }
	}
}

//vie.name = "Vie" + nbPlayer;
//energieSlider.name = "Energie" + nbPlayer;

		
/*cons = PhotonNetwork.Instantiate("cons", pos, Quaternion.identity, 0);
cons.transform.SetParent(m.transform, false);
consT = cons.GetComponent<Text>();*/

		
/*HP = PhotonNetwork.Instantiate("hp", new Vector3(250, 50, 0), Quaternion.identity, 0);
HP.transform.SetParent(m.transform, false);
hp = HP.GetComponent<Text>();*/