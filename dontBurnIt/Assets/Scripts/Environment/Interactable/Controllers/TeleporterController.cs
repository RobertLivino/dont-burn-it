using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterController : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject thisRoom;
    [SerializeField] private GameObject nextRoom;

    public void Teleport()
    {
        nextRoom.SetActive(true);
        thisRoom.SetActive(false);

        player.transform.position = destination.position;
    }


 
}
