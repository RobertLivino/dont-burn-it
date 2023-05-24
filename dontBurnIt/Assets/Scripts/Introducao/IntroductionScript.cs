using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroductionScript : MonoBehaviour
{
    public LevelLoaderScript levelLoader;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("changeScene");
    }

    // Update is called once per frame
    void Update()
    { 
    }

    IEnumerator changeScene ()
    {
        yield return new WaitForSeconds(12f);
        levelLoader.Transition(sceneName);
        //SceneManager.LoadScene("MenuScene");
    }
}
