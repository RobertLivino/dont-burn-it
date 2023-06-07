using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceController : MonoBehaviour
{
    public bool isActive;
    public bool isBurning;

    public Animator animator;

    private void Start()
    {
        isActive = false;
        animator = GetComponentInChildren<Animator>();
    }

    public void ToggleFurnace()
    {
        if(!isBurning)
        {
            isActive = !isActive;
            Debug.Log("Furnace is now: " + isActive);

            animator.SetBool("isActive", isActive);
        }
        

    }

    

}
