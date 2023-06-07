using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    Animator animator;

    DialogueController dialogue;
    [SerializeField] public int direction;


    private void Start()
    {
         dialogue = GetComponentInChildren<DialogueController>();
         animator = GetComponentInChildren<Animator>();

        animator.SetBool("isWalking", false);
        animator.SetBool("isTalking", true);
    }

    void Update()
    {
        if (!dialogue.dialogueStarted && !dialogue.dialogueEnded)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isTalking", false);
            transform.Translate(Vector3.left * speed * Time.deltaTime * direction);
        }

        if (dialogue.dialogueStarted)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isTalking", true);

        }

        if (dialogue.dialogueStarted && dialogue.dialogueEnded)
        {
            animator.SetBool("isWalking", true);
            animator.SetBool("isTalking", false);
            transform.Translate(Vector3.left * speed * Time.deltaTime * direction);
        }


    }

    
}
