using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    private bool isActive;
    [SerializeField] private AudioClip activating;
    [SerializeField] private AudioClip deactivating;

    public void SwitchState()
    {
        if (!isActive)
        {
            isActive = true;
            SoundManager.Instance.PlaySound(activating);
            Debug.Log("Lever is now on");
        }
        else
        {
            SoundManager.Instance.PlaySound(deactivating);
            isActive = false;
            Debug.Log("Lever is now off");
        }
    }

}
