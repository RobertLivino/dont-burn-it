using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnaceDoorController : MonoBehaviour
{
    bool isClosed;

    private void Start()
    {
        isClosed = true;
    }

    public void OpenDoor()
    {
        StartCoroutine("ActivateDoor");
    }

    public IEnumerator ActivateDoor()
    {
        ToggleDoor();

        yield return new WaitForSeconds(5);

        ToggleDoor();
    }

    void ToggleDoor()
    {
        isClosed = !isClosed;

        Debug.Log("Door is open? : " + isClosed);

        gameObject.GetComponent<BoxCollider2D>().enabled = isClosed;
        gameObject.GetComponent<SpriteRenderer>().enabled = isClosed;
    }
}
