using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBoule : MonoBehaviour {

	// Use this for initialization
	public GameObject rouge;
	public GameObject bleu;
	public GameObject vert;
	public GameObject jaune;
	public int index;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (index == 4)
			index = 0;
		if (index == 0)
		{
			rouge.SetActive(true);
			bleu.SetActive(false);
			vert.SetActive(false);
			jaune.SetActive(false);
		}
		if (index == 1)
		{
			rouge.SetActive(false);
			bleu.SetActive(true);
			vert.SetActive(false);
			jaune.SetActive(false);
		}
		if (index == 2)
		{
			rouge.SetActive(false);
			bleu.SetActive(false);
			vert.SetActive(true);
			jaune.SetActive(false);
		}
		if (index == 3)
		{
			rouge.SetActive(false);
			bleu.SetActive(false);
			vert.SetActive(false);
			jaune.SetActive(true);
		}
	}


}
