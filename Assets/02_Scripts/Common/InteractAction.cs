using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using System;

public class InteractAction : MonoBehaviour
{
    public float interactDistance = 3f; // ��ȣ�ۿ� ������ �ִ� �Ÿ�
    PlayerInputActions inputActions;

    Light flash;
    bool isFlashOn = false;

    [SerializeField] IInteractable interactable;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }
    private void Start()
    {
        flash = FlashHead.Inst.GetComponent<Light>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Light.performed += OnLight;
        inputActions.Player.Interact.performed += OnInteract;
    }

    private void OnDisable()
    {
        inputActions.Player.Interact.performed -= OnInteract;
        inputActions.Player.Light.performed -= OnLight;
        inputActions.Disable();
    }

    private void OnInteract(InputAction.CallbackContext obj)
    {
        // �÷��̾ 'e' Ű�� ������ ���� ��ȣ�ۿ� �Լ� ȣ��
        if (interactable != null)
        {
            // ��ȣ�ۿ� �Լ� ȣ��
            interactable.Interaction();
        }
    }

    private void OnLight(InputAction.CallbackContext obj)
    {

        isFlashOn = !isFlashOn;
        flash.enabled = isFlashOn;
    }

    void Update()
    {
       // brain.

        RaycastHit hit; // Ray�� �ε��� ��ü ������ ������ ����

        // Cinemachine Virtual Camera�� ���� Ray �߻�
       Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));

        // Ray�� Scene â�� �׸�
        Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.red);

        // Ray�� �ε��� ��ü ������ ����
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            // Ray�� �ε��� ��ü�� IInteract �������̽��� ������ �ִ��� Ȯ��
            interactable = hit.collider.GetComponent<IInteractable>();

        }
    }
}
