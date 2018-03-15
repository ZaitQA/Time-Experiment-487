using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fouille : MonoBehaviour
{

	private Text consT;
	public string[] inv;
	public int index;

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
		index = GetComponent<PlayerController>().index;
		
		if (other.tag == "fouille" && tag == "Player" && other.name == "Rien" && consT != null && Input.GetKeyDown(KeyCode.F))
		{
			consT.text = "Il n'y a rien à l'intérieur ...";
		}
		else if (other.tag == "fouille" && tag == "Player" && other.name != "Rien" && consT != null &&
		         Input.GetKeyDown(KeyCode.F))
		{
			if (inv.Length >= 1)
			{
				inv[index] = other.name;
				index += 1;
			}
			consT.text = "Tu as trouvé " + other.name;
		}
		else if (other.tag == "key" && Input.GetKeyDown(KeyCode.R) && consT != null)
		{
			if (inv.Length >= 1)
			{
				inv[index] = other.name;
				index += 1;
			}
			other.gameObject.SetActive(false);
			consT.text = "Tu as ramassé la clé " + other.name;

		}
		

	}

	private void OnTriggerExit(Collider other)
	{
		consT = GetComponent<PlayerController>().consT;
		if ((other.tag == "fouille" || other.tag == "key") && consT != null)
			consT.text = "";
	}
}
