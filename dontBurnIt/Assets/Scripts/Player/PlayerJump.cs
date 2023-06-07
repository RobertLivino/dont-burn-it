using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float coyoteTime = 0.2f;
    [SerializeField] private float jumpBufferTime = 0.2f;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;

    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        if (isGrounded())
        {
            animator.SetBool("isGrounded", true);
        }
        else
        {
            animator.SetBool("isGrounded", false);
        }

        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            Jump(); 
        }

       

       if(rb.velocity.y < 0 && !isGrounded())
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isFalling", true);
        }
        else
        {
            animator.SetBool("isFalling", false);
        }

            
        /*
        if (PlayerManager.Instance.canJump)
        {
            Jump();   
        }

        */
    }

    private void Jump()
    {
        animator.SetBool("isJumping", true);

        rb.velocity = new Vector2(rb.velocity.x, jumpForce);

        

        /*
        if (isGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        { 
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            jumpBufferCounter = 0f;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }
        */
    }

    private bool isGrounded()
    {
        bool grounded = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.02f, groundLayer);
        return grounded;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ladder"))
        {
            animator.SetBool("isJumping", false);
        }
    }

}
