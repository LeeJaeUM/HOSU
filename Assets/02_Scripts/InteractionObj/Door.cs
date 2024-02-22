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
        Debug.Log("물체와 상호 작용했습니다!");
        // 물체와의 상호 작용에 대한 추가적인 코드
        isOpen = !isOpen;
        anim.SetBool(IsOpen_Hash, isOpen);
    }
}
