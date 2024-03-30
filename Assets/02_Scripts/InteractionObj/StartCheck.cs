using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCheck : MonoBehaviour, IInteractable
{
    bool isCheck = false;
    public Action<bool> onCheck;
    [SerializeField]
    CinemachineVirtualCamera startCamera;
    BoxCollider interact;

    private void Awake()
    {
        Transform parent = transform.parent;
        startCamera = parent.GetChild(2).GetComponent<CinemachineVirtualCamera>();
        interact = GetComponent<BoxCollider>();
    }

    public void Interaction()
    {
        startCamera.Priority = 0;
        onCheck?.Invoke(isCheck);
        isCheck = true;
        interact.enabled = false;
    }

}
