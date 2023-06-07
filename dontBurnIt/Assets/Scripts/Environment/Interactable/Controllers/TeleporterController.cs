using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterController : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject thisRoom;
    [SerializeField] private GameObject nextRoom;

    [SerializeField] public bool isLocked;

    public void Teleport()
    {

        if(!isLocked)
        {
            PlayerManager.Instance.changeMainCameraBlendTime(0);

            nextRoom.SetActive(true);
            thisRoom.SetActive(false);

            player.transform.position = destination.position;
        }
        
    }


 
}
