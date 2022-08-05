using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    GameObject ExitText;
    GameObject Button;
    bool PlayerIsDead = false;


    private void Awake()
    {
        ExitText = GameObject.Find("ExitPopUp");
        Button = GameObject.Find("Button");
    }

    private void Start()
    {
        ExitText.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void HomeMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void QuitGameText()
    {
        //Pause Game
        Time.timeScale = 0;
        //PopUpText
        ExitText.SetActive(true);
        //if Button is shown, disactive it
        if (Button.activeSelf == true)
        {
            PlayerIsDead = true;
            Button.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void ContinueGame()
    {
        if (PlayerIsDead)
        {
            Button.SetActive(true);
            Button.GetComponent<AudioSource>().mute = true;
        }
        else
        {
            Button.GetComponent<AudioSource>().mute = false;
        }

        Time.timeScale = 1;
        ExitText.SetActive(false);
    }
}
