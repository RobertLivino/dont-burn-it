using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroductionScript : MonoBehaviour
{
    public LevelLoaderScript levelLoader;
    public string sceneName;

    void Start()
    {
        StartCoroutine("changeScene");
    }

    IEnumerator changeScene ()
    {
        yield return new WaitForSeconds(7.5f);
        levelLoader.Transition(sceneName);
        //SceneManager.LoadScene("MenuScene");
    }
}
