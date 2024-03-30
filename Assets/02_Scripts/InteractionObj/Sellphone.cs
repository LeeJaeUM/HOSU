using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sellphone : MonoBehaviour, IInteractable
{
    public DialogueManager dialogueManager;
    BoxCollider interact;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        interact = GetComponent<BoxCollider>();
    }
    public void Interaction()
    {
        dialogueManager.SpeakDialogue(2);

        interact.enabled = false;
    }
}
