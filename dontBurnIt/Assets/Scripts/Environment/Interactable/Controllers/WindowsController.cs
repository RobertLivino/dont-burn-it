using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowsController : MonoBehaviour
{
    [SerializeField] private Image windowView;
    [SerializeField] private bool isLookingOut;

    [SerializeField] private GameObject player;
    private PlayerMovement pMovement;

    private void Start()
    {
        pMovement = player.GetComponent<PlayerMovement>();
    }

    public void InteractWithWindow()
    {
        if(!isLookingOut)
        {
            lookOutTheWindow();
        }
        else
        {
            GetOffTheWindow();
        }
    }

    private void lookOutTheWindow()
    {
        isLookingOut = true;
        windowView.gameObject.GetComponent<Image>().enabled = true;

        pMovement.StopMoving();
        pMovement.ToggleWalk();
    }

    private void GetOffTheWindow()
    {
        isLookingOut = false;
        windowView.gameObject.GetComponent<Image>().enabled = false;
       
        pMovement.ToggleWalk();
    }
}

/*
    public bool isPressed;
    public Animator animator;
    public Transform cameraDestination; // O destino para onde a câmera deve se mover
    public FollowingCamera followingCameraScript; // Script que faz a câmera seguir o personagem

    private Vector3 originalCameraPosition;

    public void PressButton()
    {
        if (!isPressed)
        {
            isPressed = true;
            Debug.Log("Cam in other perspective");

            // Desabilita o script de seguir o personagem
            followingCameraScript.enabled = false;

            // Armazena a posição original da câmera
            originalCameraPosition = Camera.main.transform.position;

            // Move a câmera para o destino especificado
            MoveCameraToDestination();
        }
        else
        {
            isPressed = false;
            Debug.Log("Cam return to person");

            // Move a câmera de volta para a posição original
            MoveCameraToOriginalPosition();

            // Reabilita o script de seguir o personagem
            followingCameraScript.enabled = true;
        }
    }

    private void MoveCameraToDestination()
    {
        // Verifica se o destino da câmera está definido
        if (cameraDestination != null)
        {
            // Obtém o componente da câmera
            Camera mainCamera = Camera.main;

            // Verifica se há um componente de câmera na cena
            if (mainCamera != null)
            {
                // Move a posição da câmera para o destino especificado
                mainCamera.transform.position = cameraDestination.position;
                Vector3 destinationPosition = cameraDestination.position;
                destinationPosition.z = -10f;
                mainCamera.transform.position = destinationPosition;
                mainCamera.transform.rotation = cameraDestination.rotation;
            }
            else
            {
                Debug.LogError("No camera component found in the scene!");
            }
        }
        else
        {
            Debug.LogError("Camera destination is not set!");
        }
    }

    private void MoveCameraToOriginalPosition()
    {
        // Verifica se a posição original da câmera está definida
        if (originalCameraPosition != null)
        {
            // Obtém o componente da câmera
            Camera mainCamera = Camera.main;

            // Verifica se há um componente de câmera na cena
            if (mainCamera != null)
            {
                // Move a posição da câmera de volta para a posição original
                mainCamera.transform.position = originalCameraPosition;
            }
            else
            {
                Debug.LogError("No camera component found in the scene!");
            }
        }
        else
        {
            Debug.LogError("Original camera position is not set!");
        }
    }
    */