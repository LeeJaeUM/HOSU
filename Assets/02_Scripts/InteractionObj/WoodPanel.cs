using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPanel : InteractFunction, IInteractable
{
    DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = DialogueManager.Instance;
    }

    public void Interaction()
    {
        GameManager.Inst.isWoodPanelHave = true;
        Destroy(gameObject);
    }

}
