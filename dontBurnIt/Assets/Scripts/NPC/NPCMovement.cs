using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    DialogueController dialogue;

    private void Start()
    {
         dialogue = GetComponentInChildren<DialogueController>();
    }

    void Update()
    {
        if (!dialogue.dialogueStarted && !dialogue.dialogueEnded)
        {

            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (dialogue.dialogueStarted && dialogue.dialogueEnded)
        {

            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

    }

    
}
