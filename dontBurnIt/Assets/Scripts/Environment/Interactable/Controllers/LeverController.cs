using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    private bool isActive;


    public void SwitchState()
    {
        if (!isActive)
        {
            isActive = true;
            AudioManager.Instance.PlaySFX("Lever_1");
            Debug.Log("Lever is now on");
        }
        else
        {
            AudioManager.Instance.PlaySFX("Lever_2");
            isActive = false;
            Debug.Log("Lever is now off");
        }
    }

}
