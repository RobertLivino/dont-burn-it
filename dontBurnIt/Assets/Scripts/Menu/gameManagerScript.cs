using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManagerScript : MonoBehaviour
{
    //public AudioClip sfxFinal1;
    //public audioController audioController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            SceneManager.LoadScene("MenuScene"); //Alterar para tela de pause
            //Application.Quit();
        } 
    }

    //Na função de ir para o final 1 colocar o código
    //audioController.ToqueSFX(sfxFinal1);
}
