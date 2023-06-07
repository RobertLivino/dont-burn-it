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
            StartCoroutine("teste");
        }

        Destroy(collision.gameObject);
    }


    IEnumerator teste()
    {
        animator.SetTrigger("Burning");
        yield return new WaitForSeconds(10);
        animator.ResetTrigger("Burning");
    }
}
