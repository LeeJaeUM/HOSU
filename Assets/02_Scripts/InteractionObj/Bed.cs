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
        //ok Ŭ�� �� Ʈ���� ��Ȱ��ȭ �� ī�޶� �̵�
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
        //���� Ŭ��� �ƴ� �� UI ���� �׼� ����
        onGoBed?.Invoke();
    }
    private void GameClear()
    {
        //���� Ŭ���� ��
        interact.enabled = false;
        bedCamera.Priority = 0;
    }

}
