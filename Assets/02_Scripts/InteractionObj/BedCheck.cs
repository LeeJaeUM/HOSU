using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BedCheck : MonoBehaviour, IInteractable
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
        /*
        if(isCameraOn && Input.GetKeyDown(KeyCode.Q))
        {
           isCameraOn = !isCameraOn;
           bedCamera.Priority = 0;
        }*/
    }

    public void Interaction()
    {
        if (!isCameraOn)
        {
            bedCamera.Priority = 30;

            isCameraOn = true;

            GameManager.Inst.isCheck_UnderBed = true;
        }
        else
        {
            bedCamera.Priority = 0;

            isCameraOn = false;
        }
    }
}
