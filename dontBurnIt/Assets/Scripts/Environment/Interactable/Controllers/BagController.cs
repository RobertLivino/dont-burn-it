using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagController : MonoBehaviour
{
    Vector3 originalPos;
    Vector3 originalRot;

    private void Start()
    {
        originalPos = gameObject.transform.position;
        originalRot = gameObject.transform.eulerAngles;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Furnace"))
        {
            if (collision.gameObject.GetComponentInChildren<FurnaceController>().isActive)
            {
                StartCoroutine(TurnOnFurnace(collision.gameObject));
                gameObject.transform.position = originalPos;
                gameObject.transform.eulerAngles = originalRot;
            }
            
        }
        
    }

    IEnumerator TurnOnFurnace(GameObject obj)
    {
        obj.GetComponentInChildren<FurnaceController>().animator.SetBool("Burning", true);
        obj.GetComponentInChildren<FurnaceController>().isBurning = true;
        yield return new WaitForSeconds(10);
        obj.GetComponentInChildren<FurnaceController>().animator.SetBool("Burning", false);
        obj.GetComponentInChildren<FurnaceController>().isBurning = false;
    }

}
