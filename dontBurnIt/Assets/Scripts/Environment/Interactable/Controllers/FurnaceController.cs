using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceController : MonoBehaviour
{
    bool isActive;

    private Animator animator;

    private void Start()
    {
        isActive = false;
        animator = GetComponent<Animator>();
    }

    public void ToggleFurnace()
    {
        isActive = !isActive;
        Debug.Log("Furnace is now: " + isActive);

        animator.SetBool("isActive", isActive);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (animator.GetBool("isActive"))
        {

        }

        Destroy(collision.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isActive)
            {
                gameObject.GetComponent<Animator>().SetTrigger("Burning");
            }

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        gameObject.GetComponent<Animator>().ResetTrigger("Burning");
    }
}
