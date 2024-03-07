using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLiving : Door
{
    public override void Interaction()
    {
        base.Interaction();
        if (!IsOpen)
            GameManager.Inst.isDoorLock_LivingroomWindow = true;
    }
}
