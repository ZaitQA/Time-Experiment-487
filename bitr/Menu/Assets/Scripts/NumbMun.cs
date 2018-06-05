using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumbMun : MonoBehaviour {

	// Use this for initialization
	private GameObject player;

	public string arme;
	public GameObject n;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		player = GameObject.FindWithTag("Player");
		if (arme == "assaut")
		{
			n.GetComponent<Text>().text = player.GetComponent<Tir>().currentChargeurAssaut + " / " +
			                              player.GetComponent<Tir>().chargeurAssaut + "          " +
			                              player.GetComponent<Tir>().munAssaut;
		}
		if (arme == "pistolet")
		{
			n.GetComponent<Text>().text = player.GetComponent<Tir>().currentChargeurPistolet + " / " +
			                              player.GetComponent<Tir>().chargeurPistolet + "          " +
			                              player.GetComponent<Tir>().munPistolet;
		}
		if (arme == "pompe")
		{
			n.GetComponent<Text>().text = player.GetComponent<Tir>().currentChargeurPompe + " / " +
			                              player.GetComponent<Tir>().chargeurPompe + "          " +
			                              player.GetComponent<Tir>().munPompe;
		}
		if (arme == "soins")
		{
			n.GetComponent<Text>().text = player.GetComponent<PlayerController>().nbPotionSoin + "";
		}
		if (arme == "mana")
		{
			n.GetComponent<Text>().text = player.GetComponent<PlayerController>().nbPotionMana + "";
		}
	}

	public void UsePotionSoins()
	{
		if (player.GetComponent<PlayerController>().nbPotionSoin > 0 && player.GetComponent<PlayerController>().Life < player.GetComponent<PlayerController>().maxlife)
		{
			player.GetComponent<PlayerController>().Life += 25;
			player.GetComponent<PlayerController>().nbPotionSoin -= 1;
		}
	}
	public void UsePotionMana()
	{
		if (player.GetComponent<PlayerController>().nbPotionMana > 0 && player.GetComponent<PlayerController>().energieV < player.GetComponent<PlayerController>().maxenergie)
		{
			player.GetComponent<PlayerController>().energieV += 25;
			player.GetComponent<PlayerController>().nbPotionMana -= 1;
		}
	}
}
