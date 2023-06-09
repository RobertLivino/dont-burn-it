using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerClimb : MonoBehaviour
{

    [SerializeField] private float climbingSpeed = 5f;
    private bool canClimb;
    private bool isClimbing;
    private bool climbAnimation;

    private float verticalInput;

    private Rigidbody2D rb;
    private float originalGravityScale;
    public Animator animator;

    void Start()
    { 
        rb = GetComponent<Rigidbody2D>();
        originalGravityScale = rb.gravityScale;
    }

    void Update()
    {
        verticalInput = Input.GetAxisRaw("Vertical");

        Climb();
        animator.SetBool("isClimbing", isClimbing);
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x, verticalInput * climbingSpeed);
        }
        else
        {
            rb.gravityScale = originalGravityScale;
        }
    }

    private void Climb()
    {
        if (canClimb && Mathf.Abs(verticalInput) > 0f)
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
