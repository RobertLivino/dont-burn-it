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

    Animator animator;
    [SerializeField] GameObject player;
    PlayerMovement pMovementScript;

    private void Start()
    {
        animator = GetComponent<Animator>();
        pMovementScript = player.GetComponent<PlayerMovement>();

        isCrouching = false;

        playerCollider = gameObject.GetComponent<BoxCollider2D>();

        originalHeight = playerCollider.size.y;
        crouchingHeight = playerCollider.size.y / 2;

        originalYOffset = playerCollider.offset;
        crouchingYOffset = new Vector2(0, -.4f);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("isCrouching", true);
            pMovementScript.movementSpeed = pMovementScript.movementSpeed / 2;
            player.gameObject.transform.localScale = new Vector3(1.5f, 1.1f, 1);
            isCrouching = true;
            playerCollider.size = new Vector2(playerCollider.size.x, crouchingHeight);
            playerCollider.offset = crouchingYOffset;
        }

        if(Input.GetKeyUp(KeyCode.S))
        {
            animator.SetBool("isCrouching", false);
            player.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 1);
            pMovementScript.movementSpeed = pMovementScript.movementSpeed * 2;
            isCrouching = false;
            playerCollider.size = new Vector2(playerCollider.size.x, originalHeight);
            playerCollider.offset = originalYOffset;
        }
    }
}
