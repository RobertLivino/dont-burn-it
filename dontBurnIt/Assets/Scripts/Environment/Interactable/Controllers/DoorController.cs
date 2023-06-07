using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Animator animator;
    bool isClosed;

    private void Start()
    {
        animator = GetComponent<Animator>();
        isClosed = true;
    }

    public void OpenDoor()
    {
        StartCoroutine("ActivateDoor");
    }

    public IEnumerator ActivateDoor()
    {
        if(isClosed)
        {
            StartCoroutine(ToggleDoor());

            yield return new WaitForSeconds(5);

            StartCoroutine(ToggleDoor());
        }

       
    }

    public IEnumerator ToggleDoor()
    {
        if(isClosed)
        {
            isClosed = !isClosed;

            animator.SetBool("isOpening", true);

            yield return new WaitForSeconds(.8f);

            animator.SetBool("isOpening", false);
            animator.SetBool("Closed", false);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;

            yield return new WaitForSeconds(5);

            animator.SetBool("isClosing", true);

            yield return new WaitForSeconds(.8f);

            animator.SetBool("isClosing", false);
            animator.SetBool("Closed", true);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;

            isClosed = !isClosed;
        } 


    }
}

