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
		if (other.tag == "Boule" && tag == "Player" && consT != null)
		{
			consT.text = "Appuyez sur la touche K pour changer la couleur de la boule.";
		}
		if (other.tag == "Mana" && tag == "Player")
		{
			other.gameObject.SetActive(false);
			GetComponent<PlayerController>().nbPotionMana += 1;

		}
		if (other.tag == "Soins" && tag == "Player")
		{
			other.gameObject.SetActive(false);
			GetComponent<PlayerController>().nbPotionSoin += 1;

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
		         Input.GetKeyDown(KeyCode.F))
		{

				other.GetComponent<Collider>().gameObject.SetActive(false);
			if (other.name == "pistolet")
			{
				consT.text = "Tu as trouvé des munitions de pistolet (x12)";
				GetComponent<Tir>().munPistolet += 12;
			}
			if (other.name == "assaut")
			{
				consT.text = "Tu as trouvé des munitions de fusil d'assaut (x30)";
				GetComponent<Tir>().munAssaut += 12;
			}
			if (other.name == "pompe")
			{
				consT.text = "Tu as trouvé des munitions de fusil à pompe (x5)";
				GetComponent<Tir>().munPompe += 12;
			}
			if (other.name == "soin")
			{
				consT.text = "Tu as trouvé une potion de soin";

				GetComponent<PlayerController>().nbPotionSoin += 1;
			}
			if (other.name == "mana")
			{
				consT.text = "Tu as trouvé une potion de mana";
				GetComponent<PlayerController>().nbPotionMana += 1;
			}

		}
		else if (other.tag == "key" && Input.GetKeyDown(KeyCode.R) && consT != null  && inv != null && index != null)
		{

				index += 1;
			inv[index] = other.name;
				other.gameObject.SetActive(false);
				consT.text = "Tu as ramassé la clé " + other.name;

		}
		else if (other.tag == "Boule" && Input.GetKeyDown(KeyCode.K) && consT != null)
		{
			other.GetComponent<ChangeBoule>().index += 1;
		}
		

	}

	private void OnTriggerExit(Collider other)
	{
		consT = GetComponent<PlayerController>().consT;
		if ((other.tag == "fouille" || other.tag == "key") && consT != null)
			consT.text = "";
	}
}
