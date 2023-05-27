using Cinemachine;
using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;

    [SerializeField] private GameObject player;
    [SerializeField] private bool playerInRange;
    private TextMeshPro playerTextArea;

    [SerializeField] private GameObject npc;
    private TextMeshPro npcTextArea;

    bool dialogueEnded;
    bool isTyping;

    int index = 0;
    float typingSpeed = 0.02f;

    private void Start()
    {
        playerTextArea = player.gameObject.GetComponentInChildren<TextMeshPro>();
        npcTextArea = npc.gameObject.GetComponentInChildren<TextMeshPro>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(PlayerManager.Instance.interactKey))
        { 
            if(playerInRange)
            {
                if (index < dialogue.sentences.Length)
                {
                    ClearTextAreas();
                    DisplaySentence(GetCurrentSpeakerTextArea(), GetCurrentSentence());
                }
                else
                {
                    Debug.Log("There aren't more sentences");
                    EndDialogue();
                }
                    
            }   
        }    
    }

    private void StartDialogue()
    {
        Debug.Log("Dialogue started with: " + npc.name);

        PlayerManager.Instance.StopMoving();
        PlayerManager.Instance.canWalk = false;
        PlayerManager.Instance.canJump = false;

        PlayerManager.Instance.SetDialogueCanvas(true);
        PlayerManager.Instance.SetDialogueCamera(true);

        DisplaySentence(GetCurrentSpeakerTextArea(), GetCurrentSentence());
       
    }

    private void EndDialogue()
    {
        Debug.Log("Dialogue with: " + npc.name + " has ended"); ;
        dialogueEnded = true;
        ClearTextAreas();

        PlayerManager.Instance.canWalk = true;
        PlayerManager.Instance.canJump = true;

        PlayerManager.Instance.SetDialogueCanvas(false);
        PlayerManager.Instance.SetDialogueCamera(false);
    }

    private TextMeshPro GetCurrentSpeakerTextArea()
    {
        if(dialogue.sentences[index].speaker.ToString() == "Player")
        {
            return playerTextArea;
        } 
        else
        {
            return npcTextArea;
        }   
    }

    private string GetCurrentSentence()
    {
        return dialogue.sentences[index].sentence;
    }

    public void DisplaySentence(TextMeshPro textArea, string sentence)
    {
        if (!isTyping)
        {
            StartCoroutine(Type(textArea, sentence));
        }
        else
        {
            StopTyping();
            ClearTextAreas();
            textArea.text = sentence;
            index++;
        }
    }

    public void ClearTextAreas()
    {
        playerTextArea.text = "";
        npcTextArea.text = "";
    }

    IEnumerator Type(TextMeshPro textArea, string text)
    {
        textArea.text = "";

        isTyping = true;
        Debug.Log("Typing");

        int count = 0;
        foreach (char letter in text)
            {
                count++;
                if(count % 5 == 0)
                {
                    AudioManager.Instance.PlaySFX("talking");
                    count = 0;
                }
                
                textArea.text += letter;
                yield return new WaitForSeconds(typingSpeed);
            }

        isTyping = false;
        Debug.Log("Finished Typing");

        index++;     
    }

    public void StopTyping()
    {
        StopAllCoroutines();
        isTyping = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!dialogueEnded)
            {
                playerInRange = true;
                StartDialogue();
            }
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

}

