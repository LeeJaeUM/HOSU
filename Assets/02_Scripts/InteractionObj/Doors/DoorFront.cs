using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFront : Door
{
    public override void Interaction()
    {
        base.Interaction();
        if (!IsOpen)
            GameManager.Inst.isDoorLock_Front = true;
    }
}
