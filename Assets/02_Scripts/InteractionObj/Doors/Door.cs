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
        Debug.Log("��ü�� ��ȣ �ۿ��߽��ϴ�!");
        // ��ü���� ��ȣ �ۿ뿡 ���� �߰����� �ڵ�
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
        Debug.Log($"{gameObject.name}�� ���� ����{isOpen}");
    }
}
