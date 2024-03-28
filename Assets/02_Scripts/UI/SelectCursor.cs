using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectCursor : MonoBehaviour
{
    Image img1;

    Color imgColor;

    bool isVisible = false;

    private void Start()
    {
        Transform child = transform.GetChild(0);
        img1 = child.GetComponent<Image>();
        GameManager.Inst.InteractAction.onInteracAble += SetVisible;
    }

    void Update()
    {
        if (isVisible)
        {
            imgColor = img1.color;
            float animationDuration = 1.0f; //�ִϸ��̼��� ��ü �ð�
            float timePeriod = 2.0f; //�ڻ��� �Լ��� �ֱ� (2.0f�� �� �ֱ�)
            float cosTime = Mathf.Cos((Time.time % animationDuration) / animationDuration * Mathf.PI * timePeriod); //�ð��� 0���� 1 ���̷� ����ȭ�ϰ� �ڻ��� �Լ��� ����
            //imgColor.a = Mathf.Lerp(1f, 0f, (cosTime + 1) / 2); //�ڻ��� ���� 0���� 1 ���̷� �ٽ� �����Ͽ� ������ ����
            float finalZeroOne = Mathf.Lerp(1f, 0f, (cosTime + 1) / 2); //�ڻ��� ���� 0���� 1 ���̷� �ٽ� �����Ͽ� ������ ����
            imgColor.a = finalZeroOne * 0.2f;
            img1.color = imgColor;
        }
    }

    public void SetVisible()
    {
        if(!isVisible)
            StartCoroutine(SetVisible_Co());
    }

    IEnumerator SetVisible_Co()
    {
        isVisible = true;
        img1.enabled = isVisible;
        yield return new WaitForSeconds(0.1f);
        isVisible = false;
        img1.enabled = isVisible;
    }
}
