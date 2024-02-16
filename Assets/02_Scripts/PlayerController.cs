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
    Vector3 movement = Vector3.zero;
    public float moveSpeed = 3;

    public Transform MainCameraTr;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        rigid = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMoveInput;
        inputActions.Player.Move.canceled += OnMoveInput;
        inputActions.Player.Interact.performed += OnInterctInput;
    }
    private void OnDisable()
    {
        inputActions.Player.Interact.performed -= OnInterctInput;
        inputActions.Player.Move.canceled -= OnMoveInput;
        inputActions.Player.Move.performed -= OnMoveInput;
        inputActions.Player.Disable();
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
        movement = new Vector3 (moveX, 0, moveZ).normalized;
    }

    void Move()
    {
        Vector3 cameraForward = 

        rigid.velocity = movement * moveSpeed; 
    }

}
