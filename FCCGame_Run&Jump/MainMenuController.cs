using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {

        SceneManager.LoadScene("GamePlay");
        //check which botton is click (detected by .name)
        string Character = EventSystem.current.currentSelectedGameObject.name;
        //change string(only number) name to int 
        int SelectCharacter = int.Parse(Character);


        Gamemanager.instance.CharIndex = SelectCharacter;
        
    }
}
