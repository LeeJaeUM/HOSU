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
        Debug.Log("물체와 상호 작용했습니다!");
        // 물체와의 상호 작용에 대한 추가적인 코드
        isOpen = !isOpen;
        anim.SetBool(IsOpen_Hash, isOpen);
    }
}
