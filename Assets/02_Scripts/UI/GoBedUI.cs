using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GoBedUI : MonoBehaviour
{
    Bed bed;

    Image checkImage;

    //현재 게임 종료 시점인지 확인하기 위함
    bool isActive = false;
    public bool IsActive
    {
        get => isActive;
        private set
        {
            isActive = value;
        }
    }

    public Action<bool> onClickGobedUI;

    PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();

        Transform child = transform.GetChild(0);
        checkImage = child.GetComponent<Image>();
    }
    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Ok.performed += ClickOk;
        inputActions.Player.Quit.performed += ClickNo;
    }

    private void ClickOk(InputAction.CallbackContext obj)       // ok 클릭
    {
        onClickGobedUI?.Invoke(true); 
        checkImage.gameObject.SetActive(true);
    }
    private void ClickNo(InputAction.CallbackContext obj)       // no 클릭
    {
        onClickGobedUI?.Invoke(false);
        isActive = false;
        checkImage.gameObject.SetActive(isActive);
    }


    private void Start()
    {
        bed = FindAnyObjectByType<Bed>();
        bed.onGoBed += GoBed;
    }

    private void GoBed()
    {
        isActive = true; 
        checkImage.gameObject.SetActive(isActive);
    }
}
