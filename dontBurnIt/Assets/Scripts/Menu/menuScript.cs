using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    [SerializeField] private AudioClip menuSong;

    private void Start()
    {
        if(menuSong != null)
        {
            SoundManager.Instance.PlayMusic(menuSong);
        }
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        } 
    }

    public void OnClickStartGame()
    {
        //AudioSource.PlayClipAtPoint(CarlosTina, transform.position);
        SceneManager.LoadScene("FactoryScene"); //Alterar para começar no quarto
    }

    public void OnClickHowToPlay()
    {
        //AudioSource.PlayClipAtPoint(CarlosTina, transform.position);
        SceneManager.LoadScene("HowToPlayScene");
    }

    public void OnClickSettingsGame()
    {
        //AudioSource.PlayClipAtPoint(CarlosTina, transform.position);
        SceneManager.LoadScene("ConfigScene");
    }

    public void OnClickCreditsGame()
    {
        //AudioSource.PlayClipAtPoint(CarlosTina, transform.position);
        SceneManager.LoadScene("CreditsScene");
    }

    public void OnClickBackToMenu()
    {
        //AudioSource.PlayClipAtPoint(CarlosTina, transform.position);
        SceneManager.LoadScene("MenuScene");
    }

    public void OnClickExitGame()
    {
        //AudioSource.PlayClipAtPoint(CarlosTina, transform.position);
        SceneManager.LoadScene("ClosingScene");
        Debug.Log("Saindo");
        //Application.Quit();
    }
  
}
