using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    private Rigidbody2D rb;
    private Animator animator;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    public bool canWalk = true;
    public bool canJump = true;
    public bool canInteract = true;

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

    public void StopMoving()
    {
        rb.velocity *= 0;
        animator.SetFloat("isWalking", 0);
    }
}
