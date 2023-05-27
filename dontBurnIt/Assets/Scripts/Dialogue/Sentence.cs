using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class Sentence
{
    public enum Speaker
    {
        Player,
        Npc
    }

    public Speaker speaker;

    [TextArea]
    public string sentence;
}
