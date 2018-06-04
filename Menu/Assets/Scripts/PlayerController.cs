using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
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

	private int maxlife = 100;
	private int maxenergie = 100;


	private GameObject miniMap;
	private GameObject vieSlider;
	private GameObject energieSlider;
	public GameObject avatar;
	public Slider vie;
	public Slider energie;

	private GameObject deadText;
	private Text dead;
	private GameObject Loading;

	public string[] inventaire = new string[20];
	public string[] armes = new string[3];
	public int indexA = 1;
	public int index = 0;
	private GameObject m;

	private float timer = 0;
	private int nbPlayer;
	private bool deadd;
	public Animator Anim;
	private NavMeshAgent agent;
	private Vector3 hitpoint = new Vector3(0,0,0);

	private AudioSource sound;
	private AudioSource soundDeath;
	public AudioClip rip;
	public GameObject[] boules;
	public Slider vieSlide;
	public bool boolAnim1;
	public bool boolAnim2;
	
	void Start()
	{
		armes[0] = "assaut";
		boules = new GameObject[4];
		Life = GetComponent<PlayerStat>().Life;
		energieV = GetComponent<PlayerStat>().energieV;
		nbPlayer = GameObject.Find("Manager").GetComponent<Manager>().nbPlayer;
		Vector3 pos = new Vector3(105, 0, 105);
		GameObject c = PhotonNetwork.Instantiate("Main Camera", pos, Quaternion.identity, 0);
		c.name = "Main Camera" + nbPlayer;

		cam = c.GetComponent<Camera>();


		m = PhotonNetwork.Instantiate("Canvas", pos, Quaternion.identity, 0);
		m.name = "Canvas" + nbPlayer;
		m.SetActive(true);

		miniMap = GameObject.Find("RawImage");
		miniMap.transform.SetParent(m.transform, false);
		
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
		Anim = avatar.GetComponent<Animator>();
		agent = GetComponent<NavMeshAgent>();

		boolAnim1 = true;
		boolAnim2 = true;
	}

	void Update()
	{
		soundDeath = GetComponent<AudioSource>();
		if (transform.position.x == hitpoint.x && transform.position.z == hitpoint.z)
		{
			boolAnim1 = true;
			boolAnim2 = true;
			PhotonView.Get(this).RPC("PlayAnimWalk", PhotonTargets.All, false);
			PhotonView.Get(this).RPC("PlayAnimRun", PhotonTargets.All, false);

		}

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
				if (Physics.Raycast(ray, out hit, 100000, mask))
				{
					hitpoint = hit.point;
					if (!GetComponent<SpellController>().run && boolAnim1)
					{
						PhotonView.Get(this).RPC("PlayAnimWalk", PhotonTargets.All, true);
						boolAnim1 = false;
					}
						
					else if (GetComponent<SpellController>().run && boolAnim2)
					{
						PhotonView.Get(this).RPC("PlayAnimRun", PhotonTargets.All, true);
						boolAnim2 = false;
					}
					motor.MoveToPoint(hit.point);
					
				}
				

			}
			if (Input.GetMouseButton(2))
			{
				Ray ray1 = cam.ScreenPointToRay(Input.mousePosition);
				RaycastHit hit1;
				if (Physics.Raycast(ray1, out hit1, 100000, mask) && Vector3.Distance(hit1.point, transform.position) >= 3)
				{
					transform.LookAt(hit1.point);

				}


			}
			

			
			if (Input.GetKeyDown(KeyCode.L))
			{
				if (Life - 15 > 0)
					Life -= 15;
				else
				{
					Life = 0;
					deadText.SetActive(true);
				}

			}
			if (Input.GetKeyDown(KeyCode.M))
			{
				if (Life + 20 < maxlife)
					Life += 20;
				else
				{
					Life = maxlife;
				}
			}

			if (Life >= maxlife)
			{
				Life = maxlife;
			}
			else if (Life <= 0)
			{
				if (PlayerPrefs.GetInt("Resurection") == 1)
				{
					Life = 50;
					energieV = 0;
					consT.text = "Resurection !!!!!!!!!!!!!!!!!!!!!!";
				}
				else
				{
					soundDeath.clip = rip;
					soundDeath.Play();
					Life = 0;
					deadd = true;
				}

			}

			vieSlide.value = Life / maxlife;
			if(vie != null)
				vie.value = (float) Life / maxlife;
			if(energie != null)
				energie.value = (float) energieV / maxenergie;
			if (Input.GetKeyDown(KeyCode.I))
			{
				int index2 = index + 1;
				GetComponent<PlayerController>().consT.text = index2 + ":" + " " + inventaire[index];
				index += 1;
				if (inventaire[index] == "" |- index >= 10)
				{index = 0;}

			}

		}
	}

	[PunRPC]
	public void PlayAnimWalk(bool a)
	{
		Anim.SetBool("walk", a);
	}

	[PunRPC]
	public void PlayAnimRun(bool a)
	{
		Anim.SetBool("run", a);
	}
	
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "exit")
		{
			PhotonNetwork.Disconnect();
			GameObject.Find("Manager").GetComponent<LoadScene>().LoadScenes(4);
		}
		if (other.tag == "TpSalle2")
		{
			transform.position =  new Vector3(3.5f, -24, -39);
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
				Life -= 1;
			}
		}

	}



	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "laser")
		{
			Life -= 5;

		}
	}

	/*private void OnTriggerStay(Collider other)
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
		vieSlide.gameObject.SetActive(false);
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