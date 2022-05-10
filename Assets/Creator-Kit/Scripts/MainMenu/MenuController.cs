using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    [Header("Levels To load")]
    public string _newGameLevel;

    public void NewGameDiologYes()
    {
        SceneManager.LoadScene(_newGameLevel);
    }

    public void ExitButton()
    {
        Application.Quit();
    }


    // Start is called before the first frame update
    void Start()
    {
        GameObject mainMenu = GameObject.Find("Main Menu Container");
        GameObject muteButton = mainMenu.transform.Find("Mute Button").gameObject;
        GameObject unmuteButton = mainMenu.transform.Find("Unmute Button").gameObject;
        if(AudioListener.volume == 0) {
            muteButton.SetActive(false);
            unmuteButton.SetActive(true);
        }
    }

    public void muteVolume(bool mute) {
        if (mute) {
            AudioListener.volume = 0;
        } else {
            AudioListener.volume = 1;
        }
    }
 
}
