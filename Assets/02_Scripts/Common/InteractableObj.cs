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
        Debug.Log("��ü�� ��ȣ �ۿ��߽��ϴ�!");
        // ��ü���� ��ȣ �ۿ뿡 ���� �߰����� �ڵ带 ���⿡ �ۼ��� �� �ֽ��ϴ�.
    }
}
