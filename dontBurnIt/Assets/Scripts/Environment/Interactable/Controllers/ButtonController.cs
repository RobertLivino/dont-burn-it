using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public bool isPressed;
    public Animator animator;
    [SerializeField] private AudioClip _clip;

    public void PressButton()
    {
        if (!isPressed) {
            isPressed = !isPressed;
            Debug.Log("Button on ");

            SoundManager.Instance.PlaySound(_clip);

            return;
        }
        isPressed = false;
        Debug.Log("Button off ");
    }


}
