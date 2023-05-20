using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public bool isPressed;
    public Animator animator;

    public void PressButton()
    {
        if (!isPressed) {
            isPressed = !isPressed;
            Debug.Log("Button on");

            AudioManager.Instance.PlaySFX("Button_3");

            return;
        }
        isPressed = false;
        Debug.Log("Button off ");
    }


}
