using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    //public AudioClip CarlosTina;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
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

    public void OnClickExitGame()
    {
        //AudioSource.PlayClipAtPoint(CarlosTina, transform.position);
        SceneManager.LoadScene("ClosingScene");
        Debug.Log("Saindo");
        //Application.Quit();
    }
}
