using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    Animator anim;

    readonly int IsOpen_Hash = Animator.StringToHash("isOpen");

   // [SerializeField] private BoxCollider[] doorBodyColliders;
    [SerializeField] private bool isOpen = false;


    private void Start()
    {
        anim = GetComponent<Animator>();
        //doorBodyColliders = GetComponentsInChildren<BoxCollider>();
    }

    public void Interaction()
    {
        Debug.Log("��ü�� ��ȣ �ۿ��߽��ϴ�!");
        // ��ü���� ��ȣ �ۿ뿡 ���� �߰����� �ڵ�
        isOpen = !isOpen;
        anim.SetBool(IsOpen_Hash, isOpen);
    }
}
