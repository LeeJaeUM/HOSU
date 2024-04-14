using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingConditionUI : MonoBehaviour
{
    GoBedUI goBedUI;

    private void Start()
    {
        goBedUI = GameManager.Inst.GobedUI;
        goBedUI.onClickGobedUI += OnCheckCondiiton;
    }

    private void OnCheckCondiiton(bool obj)
    {
        
    }
}
