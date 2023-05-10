using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;

    [SerializeField] private float climbingSpeed = 5f;
    private bool canClimb;
    private bool isClimbing;

    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float coyoteTime = 0.2f;
    [SerializeField] private float jumpBufferTime = 0.2f;
    private float coyoteTimeCounter;
    private float jumpBufferCounter;

    [SerializeField] private LayerMask groundLayer;

    private float horizontalInput;
    private float verticalInput;

    private Rigidbody2D rb;
    private BoxCollider2D boxCollider;
    private float originalGravityScale;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravityScale = rb.gravityScale;
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        Jump();
        Climb();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * movementSpeed, rb.velocity.y);

        if(isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, verticalInput * climbingSpeed);
        }
        else
        {
            rb.gravityScale = originalGravityScale;
        }
    }

    private bool isGrounded()
    {
        return Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.02f, groundLayer);
    }

    private void Jump()
    {
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
    }

    private void Climb()
    {
        if(canClimb && Mathf.Abs(verticalInput) > 0f)
        {
            isClimbing = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            canClimb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            canClimb = false;
            isClimbing = false;
        }
    }
}
