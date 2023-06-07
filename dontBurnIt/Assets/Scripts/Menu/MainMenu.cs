using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public LevelLoaderScript levelLoader;
    public string sceneName;    
    
    public void PlayGame()
    { 
        levelLoader.Transition(sceneName);
    }

    public void CreditsScene()
    {
        SceneManager.LoadScene("Credits");        
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
