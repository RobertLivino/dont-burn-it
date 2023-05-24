using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName ="New Dialogue", menuName ="Dialogue")]
public class Dialogue : ScriptableObject
{
    public bool npcStarts = false;

    [TextArea]
    public string[] npcSentences;

    [TextArea]
    public string[] playerSentences;
  
}
