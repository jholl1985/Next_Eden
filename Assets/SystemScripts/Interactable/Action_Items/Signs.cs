using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Signs : ActionItem
{
    public string[] dialogue;
    public override void Interact()
    {
        DialogueSystem.Instance.AddNewDialogue(dialogue, "Sign ");
        Debug.Log("Interacting with Sign.");
    }
}
