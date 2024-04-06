using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Bed : InteractFunction ,IInteractable
{
    [SerializeField]
    CinemachineVirtualCamera bedCamera;
    [SerializeField]
    bool isCameraOn = false;

    public Action onGoBed;

    protected override void Awake()
    {
        base.Awake();
        bedCamera = GetComponentInChildren<CinemachineVirtualCamera>();
    }

    private void Start()
    {
        GoBedUI gobedUI = FindAnyObjectByType<GoBedUI>();
        gobedUI.onClickGobedUI += ClickBtn;

        GameManager.Inst.onGameClear += GameClear;
    }


    private void ClickBtn(bool isOk)
    {
        //ok 클릭 후 트리거 비활성화 및 카메라 이동
        if (isOk)
        {
            interact.enabled = false;
            bedCamera.Priority = 30;
        }
       // else
      //  {
      //      bedCamera.Priority = 0;
      //  }
    }

    public void Interaction()
    {
        //게임 클리어가 아닐 때 UI 생성 액션 실행
        onGoBed?.Invoke();
    }
    private void GameClear()
    {
        //게임 클리어 시
        interact.enabled = false;
        bedCamera.Priority = 0;
    }

}
