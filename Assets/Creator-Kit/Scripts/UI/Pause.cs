using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    
    public GameObject pausemenu;

    public void QuitGame() 
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        pausemenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void BackGame()
    {
        pausemenu.SetActive(false);
        Time.timeScale = 1f;
    }
}
