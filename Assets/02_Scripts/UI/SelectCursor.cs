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
            float animationDuration = 1.0f; //애니메이션의 전체 시간
            float timePeriod = 2.0f; //코사인 함수의 주기 (2.0f는 반 주기)
            float cosTime = Mathf.Cos((Time.time % animationDuration) / animationDuration * Mathf.PI * timePeriod); //시간을 0에서 1 사이로 정규화하고 코사인 함수에 적용
            //imgColor.a = Mathf.Lerp(1f, 0f, (cosTime + 1) / 2); //코사인 값을 0에서 1 사이로 다시 매핑하여 투명도를 설정
            float finalZeroOne = Mathf.Lerp(1f, 0f, (cosTime + 1) / 2); //코사인 값을 0에서 1 사이로 다시 매핑하여 투명도를 설정
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
