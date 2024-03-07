using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class InteractAction : MonoBehaviour
{
    public float interactDistance = 3f; // ��ȣ�ۿ� ������ �ִ� �Ÿ�

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

        RaycastHit hit; // Ray�� �ε��� ��ü ������ ������ ����

        // Cinemachine Virtual Camera�� ���� Ray �߻�
       Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0f));

        // Ray�� Scene â�� �׸�
        Debug.DrawRay(ray.origin, ray.direction * interactDistance, Color.red);

        // Ray�� �ε��� ��ü ������ ����
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            // Ray�� �ε��� ��ü�� IInteract �������̽��� ������ �ִ��� Ȯ��
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            // �÷��̾ 'e' Ű�� ������ ���� ��ȣ�ۿ� �Լ� ȣ��
            if (interactable != null && Input.GetKeyDown(KeyCode.E))
            {
                // ��ȣ�ۿ� �Լ� ȣ��
                interactable.Interaction();
            }
        }
    }
}
