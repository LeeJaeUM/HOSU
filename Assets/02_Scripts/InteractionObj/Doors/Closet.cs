using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Closet : MonoBehaviour, IInteractable
{
   // [SerializeField]
   // CinemachineVirtualCamera closetCamera;  //카메라 미사용
    [SerializeField]
    bool isCameraOn = false;

    public Door leftDoor;
    public Door rightDoor;

    private void Start()
    {
       //closetCamera = GetComponentInChildren<CinemachineVirtualCamera>();
        leftDoor = transform.GetChild(2).GetComponent<Door>();
        rightDoor = transform.GetChild(3).GetComponent<Door>();
    }

    private void Update()
    {
        if(!leftDoor.IsOpen && !rightDoor.IsOpen)
        {
            GameManager.Inst.isDoorLock_Closet = true;
        }
        else
        {
            GameManager.Inst.isDoorLock_Closet = false;
        }
    }

    public void Interaction()
    {
        leftDoor.DoorClose();
        rightDoor.DoorClose();
        /*
                 isCameraOn = !isCameraOn;
        if (isCameraOn)
        {
            closetCamera.Priority = 30;

            leftDoor.DoorClose();
            rightDoor.DoorClose();
        }
        else
        {
            closetCamera.Priority = 0;
        }
         */

    }
}
