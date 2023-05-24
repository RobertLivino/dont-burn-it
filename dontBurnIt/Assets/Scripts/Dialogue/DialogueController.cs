using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class DialogueController : MonoBehaviour
{

    [SerializeField] private Dialogue dialogue;
    [SerializeField] private bool dialogueStarted;
    [SerializeField] private float typingSpeed = 0.02f;

    [SerializeField] private bool playerInRange;

    [SerializeField] private TextMeshPro playerTextArea;
    [SerializeField] private TextMeshPro npcTextArea;


    string[] playerSentences;
    int playerIndex = 0;
    bool playerIsTalking;

    string[] npcSentences;
    int npcIndex = 0;

    private void Start()
    { 
        playerInRange = false;
        playerSentences = dialogue.playerSentences;
        npcSentences = dialogue.npcSentences;
    }

    private void Update()
    {
        if(playerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!dialogueStarted)
                {
                    StartDialogue();
                    dialogueStarted = true;
                }
                else
                {
                    if (playerIsTalking)
                    {
                        DisplayNpcSentence();
                    }
                    else
                    {
                        DisplayPlayerSentence();
                    }
                }

            }
        }
        
    }

    public void StartDialogue()
    {
        PlayerManager.Instance.StopMoving();

        PlayerManager.Instance.canWalk = false;
        PlayerManager.Instance.canJump = false;
        PlayerManager.Instance.canInteract = false;

        if (!dialogue.npcStarts)
        {
            DisplayPlayerSentence();
        }
        else
        {
            DisplayNpcSentence();
        }
    }

    public void EndDialogue()
    {

        PlayerManager.Instance.canWalk = true;
        PlayerManager.Instance.canJump = true;
        PlayerManager.Instance.canInteract = true;

        playerTextArea.text = "";
        npcTextArea.text = "";
    }

    public void DisplayPlayerSentence()
    {
        if(playerIndex < playerSentences.Length)
        {
            playerIsTalking = true;
            StartCoroutine(Type(playerTextArea, playerSentences[playerIndex]));
            playerIndex++;
            
            npcTextArea.text = "";
        }
        else
        {
            EndDialogue();
        }

        
    }

    public void DisplayNpcSentence()
    {
        if (playerIndex < npcSentences.Length)
        {
            StartCoroutine(Type(npcTextArea, npcSentences[npcIndex]));
            npcIndex++;
            playerIsTalking = false;
            playerTextArea.text = "";
        }
        else
        {
            EndDialogue();
        }
        
    }

    IEnumerator Type(TextMeshPro textArea, string text)
    {
        foreach(char letter in text)
        {
            textArea.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        playerInRange = true;  
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerInRange = false;
    }


}
