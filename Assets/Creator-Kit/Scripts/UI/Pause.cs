using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public void Hom(){
        pausemenu.SetActive(false);
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1f;
    }
}
