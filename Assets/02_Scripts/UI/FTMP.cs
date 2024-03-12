using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FTMP : MonoBehaviour
{
    public Image background;
    public TextMeshProUGUI tmp1;
    public TextMeshProUGUI tmp2;
    public TextMeshProUGUI tmp3;

    public float temp = 0.1f;
    public float endTime = 2;
    public float testno = 0;

    private void Awake()
    {
        background = transform.GetChild(0).GetComponent<Image>();
        tmp1 = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        tmp2 = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        tmp3 = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        StartCoroutine(Start_Co());
    }
    public Color imageColor;
    public Color textColor;
    IEnumerator Start_Co()
    {
        yield return new WaitForSeconds(2f);
        while (temp < endTime)
        {
            float normalizedTime = temp / endTime ;
            testno = normalizedTime;
            temp += Time.deltaTime;
            Debug.Log(testno);
            //이미지 알파값 투명하게 만들기
            imageColor = background.color;
            imageColor.a = Mathf.Lerp(1f, 0f, normalizedTime);
            background.color = imageColor;

            //텍스트 알파값 투명하게 만들기
            textColor = tmp1.color;
            textColor.a = Mathf.Lerp(1f, 0f, normalizedTime);
            tmp1.color = textColor;
            tmp2.color = textColor;
            tmp3.color = textColor;
            yield return null;
        }
    }
}
