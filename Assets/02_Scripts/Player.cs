using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Ray interactRay;



    private void OnTriggerEnter(Collider other)
    {
        // �浹�� ��ü�� ��ȣ �ۿ� ������ ��ü���� Ȯ���մϴ�.
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            // ��ü�� ��ȣ �ۿ��մϴ�.
            interactable.Interact();
        }
    }
}
