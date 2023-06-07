using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowsController : MonoBehaviour
{
    [SerializeField] private Image windowView;
    [SerializeField] private GameObject zepelin;
    private Vector3 zepelinOriginalPosition;

    [SerializeField] private bool isLookingOut;

    [SerializeField] private GameObject player;
    private PlayerMovement pMovement;

    private void Start()
    {
        pMovement = player.GetComponent<PlayerMovement>();

        
        zepelin.gameObject.SetActive(false);
        zepelinOriginalPosition = zepelin.transform.localPosition;
    }

    private void Update()
    {
        if(zepelin.transform.localPosition.x < -1200)
        {
            zepelin.SetActive(false);
            zepelin.transform.localPosition = zepelinOriginalPosition;
        }

    }

    public int RandomZepelinAppeareance()
    {
        return Random.Range(1, 4);
    }

    public void InteractWithWindow()
    {
        if(!isLookingOut)
        {
            lookOutTheWindow();
        }
        else
        {
            GetOffTheWindow();
        }
    }

    private void lookOutTheWindow()
    {
        isLookingOut = true;
        windowView.gameObject.GetComponent<Image>().enabled = true;

        if(RandomZepelinAppeareance() == 1)
        {
            zepelin.SetActive(true);
        }
        

        PlayerManager.Instance.StopMoving();
        PlayerManager.Instance.ToggleWalk();
    }

    private void GetOffTheWindow()
    {
        isLookingOut = false;
        windowView.gameObject.GetComponent<Image>().enabled = false;

        if(zepelin.activeSelf)
        {
            zepelin.SetActive(false);
            zepelin.transform.localPosition = zepelinOriginalPosition;


        }

        
        PlayerManager.Instance.ToggleWalk();
    }
}

