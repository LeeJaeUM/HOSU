using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InteractAction : MonoBehaviour
{
    public float interactDistance = 3f; // 상호작용 가능한 최대 거리

    Light flash;
    bool isFlashOn = false;

    private void Start()
    {
        flash = FlashHead.Inst.GetComponent<Light>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFlashOn = !isFlashOn;
            flash.enabled = isFlashOn;
        }

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
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            // 플레이어가 'e' 키를 눌렀을 때만 상호작용 함수 호출
            if (interactable != null && Input.GetKeyDown(KeyCode.E))
            {
                // 상호작용 함수 호출
                interactable.Interaction();
            }
        }
    }
}
