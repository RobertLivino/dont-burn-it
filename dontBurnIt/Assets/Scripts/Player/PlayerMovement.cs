using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float movementSpeed = 5f;

    private float horizontalInput;
    private bool canWalk = true;
    private bool facingRight = true;
    
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");   
    }

    private void FixedUpdate()
    {
        if(canWalk)
        {
            rb.velocity = new Vector2(horizontalInput * movementSpeed, rb.velocity.y);

            if(horizontalInput > 0 && !facingRight)
            {
                FlipCharacter();
            }

            if (horizontalInput < 0 && facingRight)
            {
                FlipCharacter();
            }

            animator.SetFloat("isWalking", Mathf.Abs(horizontalInput));

        }   
    }  
    
    public void ToggleWalk()
    {
        if (!canWalk)
        {
            canWalk = true;
        }
        else
        {
            canWalk = false;
        }
    }

    public void FlipCharacter()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }

    public void StopMoving()
    {
        rb.velocity *= 0;
    }
}
