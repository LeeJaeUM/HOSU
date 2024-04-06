using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
using System;

public class InteractAction : MonoBehaviour
{
    public float interactDistance = 3f; // 상호작용 가능한 최대 거리
    PlayerInputActions inputActions;

    Light flash;
    bool isFlashOn = false;

    [SerializeField] IInteractable interactable;
    public Action onInteracAble;

    public bool isStartBlock = true;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
    }
    private void Start()
    {
        FlashHead flashHead = GameManager.Inst.FlashHead;
        flash = flashHead.GetComponent<Light>();
        StartCoroutine(StartBlock());
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
        // 플레이어가 'e' 키를 눌렀을 때만 상호작용 함수 호출
        if (interactable != null && !isStartBlock)
        {
            // 상호작용 함수 호출
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

        RaycastHit hit; // Ray에 부딪힌 물체 정보를 저장할 변수

        // Cinemachine Virtual Camera를 통해 Ray 발사
       Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));

        // Ray를 Scene 창에 그림
        Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.red);

        // Ray에 부딪힌 물체 정보를 저장
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            // Ray에 부딪힌 물체가 IInteract 인터페이스를 가지고 있는지 확인
            //Debug.Log(hit.collider.name);
            interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
                onInteracAble?.Invoke();

        }
    }

    IEnumerator StartBlock()
    {
        //yield return new WaitForSeconds(16f);
        yield return new WaitForSeconds(0.1f);
        isStartBlock = false;
    }
}
