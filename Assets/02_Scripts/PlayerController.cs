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
        
        Cursor.lockState = CursorLockMode.Locked;   // ���콺 Ŀ���� ȭ�� �ȿ��� ����
        //Cursor.visible = false;                     // ���콺 Ŀ���� ������ �ʵ��� ����

        //cam = Camera.main;                          // ���� ī�޶� �Ҵ�
        cam = GetComponentInChildren<CinemachineVirtualCamera>();// ���� ī�޶� �Ҵ�
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

        yRotation += _mouseX;    // ���콺 X�� �Է¿� ���� ���� ȸ�� ���� ����
        xRotation -= _mouseY;    // ���콺 Y�� �Է¿� ���� ���� ȸ�� ���� ����

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // ���� ȸ�� ���� -90������ 90�� ���̷� ����

        cam.transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); // ī�޶��� ȸ���� ����
        transform.rotation = Quaternion.Euler(0, yRotation, 0);             // �÷��̾� ĳ������ ȸ���� ����
    }

}
