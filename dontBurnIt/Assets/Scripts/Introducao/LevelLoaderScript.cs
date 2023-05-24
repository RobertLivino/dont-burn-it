using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{
    public Animator transitionAnim;

    public void Transition(string sceneName){
        StartCoroutine(LoadScenes(sceneName));
    }

    IEnumerator LoadScenes(string sceneName){
        transitionAnim.SetTrigger("Start");

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneName);
    }
}
