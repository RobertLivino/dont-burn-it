using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FurnaceTrigger : MonoBehaviour
{

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (GetComponentInChildren<FurnaceController>().isActive)
        {
            StartCoroutine("TurnOnFurnace");
            Destroy(collision.gameObject);
        }
    }

    IEnumerator TurnOnFurnace()
    {
        GetComponentInChildren<FurnaceController>().animator.SetBool("Burning", true);
        GetComponentInChildren<FurnaceController>().isBurning = true;
        yield return new WaitForSeconds(10);
        GetComponentInChildren<FurnaceController>().animator.SetBool("Burning", false);
        GetComponentInChildren<FurnaceController>().isBurning = false;

        yield return new WaitForSeconds(5);

        SceneManager.LoadScene("End1Scene");
    }
}
