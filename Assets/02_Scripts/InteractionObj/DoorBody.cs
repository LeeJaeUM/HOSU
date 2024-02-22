using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBody : MonoBehaviour
{
    public BoxCollider doorBodyCol;

    private void Awake()
    {
        doorBodyCol = GetComponent<BoxCollider>();
    }
}
