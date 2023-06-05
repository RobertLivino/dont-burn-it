using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;
    private Rigidbody2D rb;
    private Animator animator;

    public KeyCode interactKey = KeyCode.E;
    [SerializeField] private Canvas dialogueCanvas;
    [SerializeField] private GameObject dialogueCamera;
    [SerializeField] private GameObject mainCamera;

    private void Awake()
    {
        
        if(Instance == null)
        {
            Instance = this;
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
        animator.SetFloat("Speed", 0);
    }

    public void SetDialogueCanvas(bool state)
    {
        dialogueCanvas.gameObject.SetActive(state);
    }

    public void SetDialogueCamera(bool state)
    {
       changeMainCameraBlendTime(1f);
       dialogueCamera.GetComponent<CinemachineVirtualCamera>().Priority = state ? 11 : 10;
       dialogueCamera.SetActive(state);
    }

    public void changeMainCameraBlendTime(float time)
    {
        mainCamera.GetComponent<CinemachineBrain>().m_DefaultBlend.m_Time = time;
    }
}
