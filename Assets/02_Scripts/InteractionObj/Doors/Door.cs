using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    protected Animator anim;

    readonly protected int IsOpen_Hash = Animator.StringToHash("isOpen");

    [SerializeField] protected bool isOpen = false;
    public bool IsOpen
    {
        get { return isOpen; }
        protected set
        {
            if(isOpen != value)
            {
                isOpen = value;
            }
        }
    }


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public virtual void Interaction()
    {
        Debug.Log("물체와 상호 작용했습니다!");
        // 물체와의 상호 작용에 대한 추가적인 코드
        isOpen = !isOpen;
        anim.SetBool(IsOpen_Hash, isOpen);
    }

    public void DoorClose()
    {
        StartCoroutine(DoorClose_Co());
    }

    IEnumerator DoorClose_Co()
    {
        yield return new WaitForSeconds(0.5f);
        isOpen = false;
        anim.SetBool(IsOpen_Hash, isOpen);
        Debug.Log($"{gameObject.name}의 문이 닫힘{isOpen}");
    }
}
