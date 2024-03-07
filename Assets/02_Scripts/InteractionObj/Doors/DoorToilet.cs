using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToilet : Door
{
    public override void Interaction()
    {
        base.Interaction();
        if (!IsOpen)
            GameManager.Inst.isDoorLock_Toilet = true;
    }
}
