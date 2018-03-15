using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	public Camera cam;
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
	
	public string[] inventaire = new string[10];
	public int index = 0;
	private GameObject m;

	private float timer = 0;
	private int nbPlayer;
	private bool deadd;

	void Start()
	{

		Debug.Log(nbPlayer);
		nbPlayer = GameObject.Find("Manager").GetComponent<Manager>().nbPlayer;
		Vector3 pos = new Vector3(105, 0, 105);
		GameObject c = PhotonNetwork.Instantiate("Main Camera", pos, Quaternion.identity, 0);
		c.name = "Main Camera" + nbPlayer;

		cam = c.GetComponent<Camera>();


		m = PhotonNetwork.Instantiate("Canvas", pos, Quaternion.identity, 0);
		m.name = "Canvas" + nbPlayer;
		m.SetActive(true);
		
		hpslider = GameObject.Find("Slider").GetComponent<Slider>();
		hpslider.name = "Slider" + nbPlayer;
		consT = GameObject.Find("cons").GetComponent<Text>();
		consT.name = "con" + nbPlayer;
		hp = GameObject.Find("hp").GetComponent<Text>();
		hp.name = "hp" + nbPlayer;

		/*HPslider = PhotonNetwork.Instantiate("Slider", new Vector3(250, 50, 0), Quaternion.identity, 0);
		HPslider.transform.SetParent(m.transform, false);
		hpslider = HPslider.GetComponent<Slider>();
		
		cons = PhotonNetwork.Instantiate("cons", pos, Quaternion.identity, 0);
		cons.transform.SetParent(m.transform, false);
		consT = cons.GetComponent<Text>();*/
		
		deadText = PhotonNetwork.Instantiate("Dead", pos, Quaternion.identity, 0);
		deadText.transform.SetParent(m.transform, false);
		dead = deadText.GetComponent<Text>();
		dead.name = "Dead" + nbPlayer;
		
		/*HP = PhotonNetwork.Instantiate("hp", new Vector3(250, 50, 0), Quaternion.identity, 0);
		HP.transform.SetParent(m.transform, false);
		hp = HP.GetComponent<Text>();*/
		
		c.GetComponent<Camera>().enabled = true;
		c.GetComponent<AudioListener>().enabled = true;
		c.GetComponent<CameraController>().enabled = true;
		c.GetComponent<CameraController>().target = transform;
		cam = c.GetComponent<Camera>();
		motor = GetComponent<PlayerMotor>();
		hp.text = life + " / " + maxlife;
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
			deadText.SetActive(false);
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

			hp.text = life + " / " + maxlife;
			hpslider.value = (float) life / maxlife;

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
}