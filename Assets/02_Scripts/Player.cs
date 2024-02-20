using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Ray interactRay;



    private void OnTriggerEnter(Collider other)
    {
        // 충돌한 물체가 상호 작용 가능한 물체인지 확인합니다.
        IInteractable interactable = other.GetComponent<IInteractable>();
        if (interactable != null)
        {
            // 물체와 상호 작용합니다.
            interactable.Interact();
        }
    }
}
