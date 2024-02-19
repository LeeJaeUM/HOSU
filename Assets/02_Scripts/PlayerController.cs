using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInputActions inputActions;

    Rigidbody rigid;

    float moveX = 0;
    float moveZ = 0;
    float mouseX = 0;
    float mouseY = 0;
    Vector3 movement = Vector3.zero;
    public float moveSpeed = 3;

    public Transform MainCameraTr;
    [Header("Rotate")]
    public float mouseSpeed = 1;
    float yRotation;
    float xRotation;
    //public Camera cam;
    public CinemachineVirtualCamera cam; 

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        rigid = GetComponent<Rigidbody>(); 
        rigid.freezeRotation = true;
        
        Cursor.lockState = CursorLockMode.Locked;   // 마우스 커서를 화면 안에서 고정
        //Cursor.visible = false;                     // 마우스 커서를 보이지 않도록 설정

        //cam = Camera.main;                          // 메인 카메라를 할당
        cam = GetComponentInChildren<CinemachineVirtualCamera>();// 메인 카메라를 할당
    }

    private void FixedUpdate()
    {
        Move();
    }
    private void Update()
    {
        Rotate();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMoveInput;
        inputActions.Player.Move.canceled += OnMoveInput;
        inputActions.Player.Interact.performed += OnInterctInput;
        inputActions.Player.Look.performed += OnLookInput;
    }

    private void OnDisable()
    {
        inputActions.Player.Look.performed -= OnLookInput;
        inputActions.Player.Interact.performed -= OnInterctInput;
        inputActions.Player.Move.canceled -= OnMoveInput;
        inputActions.Player.Move.performed -= OnMoveInput;
        inputActions.Player.Disable();
    }

    private void OnLookInput(InputAction.CallbackContext context)
    {
        SetupMouseInput(context.ReadValue<Vector2>());
    }

    private void OnInterctInput(InputAction.CallbackContext obj)
    {
        
    }

    private void OnMoveInput(InputAction.CallbackContext obj)
    {
        SetupInput(obj.ReadValue<Vector2>());
    }

    void SetupInput(Vector2 input)
    {
        moveX = input.x;
        moveZ = input.y;
        movement = transform.right * moveX + transform.forward * moveZ;
    }

    void Move()
    {
        rigid.velocity = movement.normalized * moveSpeed; 
        //transform.position += movement.normalized * moveSpeed * Time.fixedDeltaTime;
    }

    void SetupMouseInput(Vector2 input)
    {
        mouseX = input.x;
        mouseY = input.y;   
    }

    void Rotate()
    {
        float _mouseX = mouseX * mouseSpeed * Time.deltaTime;
        float _mouseY = mouseY * mouseSpeed * Time.deltaTime;

        yRotation += _mouseX;    // 마우스 X축 입력에 따라 수평 회전 값을 조정
        xRotation -= _mouseY;    // 마우스 Y축 입력에 따라 수직 회전 값을 조정

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // 수직 회전 값을 -90도에서 90도 사이로 제한

        cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); // 카메라의 회전을 조절
        transform.rotation = Quaternion.Euler(0, yRotation, 0);             // 플레이어 캐릭터의 회전을 조절
    }

}
