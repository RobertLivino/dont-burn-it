using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterController : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private GameObject player;

    public void Teleport()
    {
        player.transform.position = destination.position;
    }
 
}
