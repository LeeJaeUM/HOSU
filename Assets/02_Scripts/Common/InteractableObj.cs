using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObj : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Interact();
    }

    public void Interact()
    {
        Debug.Log("물체와 상호 작용했습니다!");
        // 물체와의 상호 작용에 대한 추가적인 코드를 여기에 작성할 수 있습니다.
    }
}
