using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fouille : MonoBehaviour
{

	private Text consT;
	public string[] inv;
	public int index = 0;

	private void OnTriggerEnter(Collider other)
	{
		consT = GetComponent<PlayerController>().consT;

		if (other.tag == "fouille" && tag == "Player" && consT != null)
		{
			consT.text = "Appuyer sur la touche F pour fouiller.";

		}
		if (other.tag == "key" && tag == "Player" && consT != null)
		{
			consT.text = "Appuyez sur la touche R pour ramasser la clé.";
		}
	}

	private void OnTriggerStay(Collider other)
	{
		consT = GetComponent<PlayerController>().consT;
		inv = GetComponent<PlayerController>().inventaire;
		if (other.tag == "fouille" && tag == "Player" && other.name == "Rien" && consT != null && Input.GetKeyDown(KeyCode.F))
		{
			consT.text = "Il n'y a rien à l'intérieur ...";
		}
		else if (other.tag == "fouille" && tag == "Player" && other.name != "Rien" && consT != null &&
		         Input.GetKeyDown(KeyCode.F) && inv != null && index != null)
		{

				other.GetComponent<Collider>().gameObject.SetActive(false);
				Debug.Log(index);
				inv[index] = other.name;
				index += 1;
				Debug.Log(index);
				consT.text = "Tu as trouvé " + other.name;
		}
		else if (other.tag == "key" && Input.GetKeyDown(KeyCode.R) && consT != null  && inv != null && index != null)
		{

				Debug.Log(index);
				inv[index] = other.name;
				index += 1;
				other.gameObject.SetActive(false);
				//PhotonView.Get(GameObject.Find("Salle d'opération")).RPC("Keyy", PhotonTargets.All, other);
				//PhotonView.Get(other.gameObject).RPC("Keyy", PhotonTargets.All, other);
				Debug.Log(index);
				consT.text = "Tu as ramassé la clé " + other.name;

		}
	}
	

	private void OnTriggerExit(Collider other)
	{
		consT = GetComponent<PlayerController>().consT;
		if ((other.tag == "fouille" || other.tag == "key") && consT != null)
			consT.text = "";
	}
	
	[PunRPC]
	private void Keyy(Collider other)
	{
		
		PhotonNetwork.Destroy(other.gameObject);
		other.gameObject.SetActive(false);
	}
}
