using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Bed : MonoBehaviour ,IInteractable
{
    [SerializeField]
    CinemachineVirtualCamera bedCamera;
    [SerializeField]
    bool isCameraOn = false;

    private void Start()
    {
        bedCamera = GetComponentInChildren<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if(isCameraOn && Input.GetKeyDown(KeyCode.E))
        {
            isCameraOn = !isCameraOn;
            bedCamera.Priority = 0;
        }
    }

    public void Interaction()
    {
        isCameraOn = !isCameraOn;
        if (isCameraOn)
        {
            bedCamera.Priority = 30;
        }
        else
        {
            bedCamera.Priority = 0;
        }
    }
}
