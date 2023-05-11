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
            Debug.Log("Lever is now on");
        }
        else
        {
            isActive = false;
            Debug.Log("Lever is now off");
        }
    }

}
