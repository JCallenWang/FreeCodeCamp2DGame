using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    //store GameObject 
    [SerializeField]
    private GameObject[] Character;


    //Creater Instance that can use public function when calling
    public static Gamemanager instance;
    //Can be access to multi-class and have diffent value during other class
    int _charIndex;
    public int CharIndex
    {
        get { return _charIndex; }
        set { _charIndex = value; }
    }

    private void Awake()
    {
        //Shift gameObject to other scene, and destroy any copies        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }  
    }

    private void OnEnable()
    {
        //sceneLoaded execute will also execute "OnlevelFinishedLoading"
        SceneManager.sceneLoaded += OnlevelFinishedLoading;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnlevelFinishedLoading;
    }

    //instantiate character that is picked 
    void OnlevelFinishedLoading(Scene scene,LoadSceneMode mode)
    {
        if(scene.name == "GamePlay")
        {
            Instantiate(Character[CharIndex]);  
        }
    }
}
