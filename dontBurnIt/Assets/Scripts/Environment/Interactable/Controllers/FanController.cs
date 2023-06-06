using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanController : MonoBehaviour
{

    private bool isActive;

    private void Start()
    {
        isActive = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<AreaEffector2D>().enabled = false;
    }

    public void TurnOn()
    {
        StartCoroutine("ActivateFan");
    }

    public IEnumerator ActivateFan()
    {
        ToggleFan();

        yield return new WaitForSeconds(5);

        ToggleFan();
    }

    void ToggleFan()
    {
        isActive = !isActive;

        Debug.Log("Fan is now: " + isActive);

        gameObject.GetComponent<BoxCollider2D>().enabled = isActive;
        gameObject.GetComponent<AreaEffector2D>().enabled = isActive;

    }

}
