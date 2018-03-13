using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuprincipal : MonoBehaviour


{
    public void PlayGame()
    {
        SceneManager.LoadScene("Niveau1E-3");
    }
    
    public void LevelMenu()
    {
        SceneManager.LoadScene("level");
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
