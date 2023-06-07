using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorController : MonoBehaviour
{

    private bool isActive;
    private float conveyorSpeed;

    public void ToggleConveyor()
    {
        isActive = !isActive;

        Debug.Log("Conveyor is active? : " + isActive);

        if(isActive)
        {
            conveyorSpeed = 5f;
        } else
        {
            conveyorSpeed = 0f;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(conveyorSpeed, rb.velocity.y);
       
    }


}
