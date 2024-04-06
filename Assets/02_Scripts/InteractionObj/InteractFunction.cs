using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractFunction : MonoBehaviour
{
    protected BoxCollider interact;

    protected virtual void Awake()
    {
        interact = GetComponent<BoxCollider>();
    }

    protected void InteractBoxOff()
    {
        interact.enabled = false;
    }
}
