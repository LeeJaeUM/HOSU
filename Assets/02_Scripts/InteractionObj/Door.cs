using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    Animator anim;

    readonly int IsOpen_Hash = Animator.StringToHash("isOpen");

    [SerializeField] private BoxCollider doorBodyCollider;
    [SerializeField] private bool isOpen = false;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        DoorBody doorBody = GetComponentInChildren<DoorBody>();
        doorBodyCollider = doorBody.doorBodyCol;
    }
    public void Interaction()
    {
        Debug.Log("��ü�� ��ȣ �ۿ��߽��ϴ�!");
        // ��ü���� ��ȣ �ۿ뿡 ���� �߰����� �ڵ�
        isOpen = !isOpen;
        anim.SetBool(IsOpen_Hash, isOpen);
    }
}
