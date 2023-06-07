using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouching : MonoBehaviour
{
    private BoxCollider2D playerCollider;

    private float originalHeight;
    private float crouchingHeight;

    private Vector2 originalYOffset;
    private Vector2 crouchingYOffset;

    private Vector2 originalOffset;
    private Vector2 crouchingOffset;

    private bool isCrouching;

    private void Start()
    {
        isCrouching = false;

        playerCollider = gameObject.GetComponent<BoxCollider2D>();

        originalHeight = playerCollider.size.y;
        crouchingHeight = playerCollider.size.y / 2;

        originalYOffset = playerCollider.offset;
        crouchingYOffset = new Vector2(0, -.22f);

}

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            isCrouching = true;
            playerCollider.size = new Vector2(playerCollider.size.x, crouchingHeight);
            playerCollider.offset = crouchingYOffset;
        }

        if(Input.GetKeyUp(KeyCode.S))
        {
            isCrouching = false;
            playerCollider.size = new Vector2(playerCollider.size.x, originalHeight);
            playerCollider.offset = originalOffset;
        }
    }
}
