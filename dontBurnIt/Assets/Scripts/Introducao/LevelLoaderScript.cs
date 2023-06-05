using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{
    public static Animator transitionAnim;

    public static LevelLoaderScript Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        transitionAnim = GetComponentInChildren<Animator>();
    }

    public void Transition(string sceneName){
        StartCoroutine(LoadScenes(sceneName));
    }

    IEnumerator LoadScenes(string sceneName){
        StartTransition();
        SceneManager.LoadScene(sceneName);
        yield return new WaitForSeconds(0.1f);     
    }

    public static void StartTransition()
    {
        transitionAnim.SetTrigger("Start");
    }
}
