using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{

	public GameObject Loading;
	public Slider slider;
	public Text Text;
	
	public void LoadScenes(int scene)
	{
		StartCoroutine(LoadAsync(scene));
	}

	IEnumerator LoadAsync(int scene)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(scene);

		Loading.SetActive(true);
		while (operation.isDone == false)
		{
			float progress = Mathf.Clamp01(operation.progress / .9f);

			slider.value = progress;
			Text.text = "" + (int)progress * 100 + " %";
			yield return null;
		}
	}
}
