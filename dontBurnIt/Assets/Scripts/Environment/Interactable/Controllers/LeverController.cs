using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    private bool isActive;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void SwitchState()
    {
        if (!isActive)
        {
            AudioManager.Instance.PlaySFX("Lever_1");
            Debug.Log("Lever is now on");
            StartCoroutine(LeverAnimation(!isActive));
            
        }
        else
        {
            AudioManager.Instance.PlaySFX("Lever_2");
            isActive = false;
            Debug.Log("Lever is now off");
            StartCoroutine(LeverAnimation(isActive));
        }
    }

    IEnumerator LeverAnimation(bool active)
    {
        if(active)
        {
            isActive = true;
            animator.SetBool("isTurningOn", true);

            yield return new WaitForSeconds(.4f);

            animator.SetBool("isTurningOn", false);
            animator.SetBool("Off", false);
        }
        else
        {
            isActive = false;
            animator.SetBool("isTurningOff", true);

            yield return new WaitForSeconds(.4f);

            animator.SetBool("isTurningOff", false);
            animator.SetBool("Off", true);
        }
        
    }

}
