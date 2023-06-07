using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    private float verticalInput;
    private bool isInRange = false;
    private bool isColliding = false;
    
    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");

        if (isInRange)
        {
            if (isInRange && isColliding && verticalInput < 0)
            {
                GetComponent<PlatformEffector2D>().surfaceArc = 0;
            }

            if (isInRange && verticalInput > 0)
            {
                GetComponent<PlatformEffector2D>().surfaceArc = 180;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = true;

            
        }


        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isInRange = false;

            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            isColliding = true;
            collision.gameObject.GetComponent<PlayerCrouching>().enabled = false;
        } 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")){
            isColliding = false;
            collision.gameObject.GetComponent<PlayerCrouching>().enabled = true;
        } 
    }

}
