using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowL : InteractFunction, IInteractable
{
    GameObject woods;
    private void Start()
    {
        Transform child = transform.GetChild(1);
        woods = child.gameObject;
    }
    public void Interaction()
    {
        if (GameManager.Inst.isWoodPanelHave)
        {
            woods.SetActive(true);
            GameManager.Inst.isWindowBlockwood_Livingroom = true;
            InteractBoxOff();
        }
    }
}
