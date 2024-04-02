using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sellphone : InteractFunction, IInteractable
{
    public DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }
    public void Interaction()
    {
        dialogueManager.SpeakDialogue(2);
        InteractBoxOff();
    }
}
