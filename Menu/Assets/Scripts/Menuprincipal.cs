using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuprincipal : MonoBehaviour


{
    
    public void PlayGame()
    {
        SceneManager.LoadScene(2);
    }
    
    public void LevelMenu()
    {
        SceneManager.LoadScene(1);
        Debug.Log(SceneManager.sceneCount);
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);

    }

    public void BackMenuFromGame()
    {
        GameObject.Find("Manager").GetComponent<Manager>().Quit();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
