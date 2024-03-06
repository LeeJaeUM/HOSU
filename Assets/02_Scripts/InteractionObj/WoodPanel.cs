using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPanel : MonoBehaviour, IInteractable
{
    public void Interaction()
    {
        GameManager.Inst.isWoodPanelHave = true;
        Destroy(gameObject);
    }

}
