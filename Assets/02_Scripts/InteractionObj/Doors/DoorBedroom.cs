using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBedroom : Door
{
    public override void Interaction()
    {
        base.Interaction();
        if (!IsOpen)
            GameManager.Inst.isDoorLock_Bedroom = true;
    }
}
