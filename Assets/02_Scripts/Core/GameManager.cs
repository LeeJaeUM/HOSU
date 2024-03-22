using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager Inst;

    private void Awake()
    {
        if(Inst != null)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Inst = this;
            DontDestroyOnLoad(gameObject);
        }
        onDia2End += Dia2End;

        lights = GetComponentsInChildren<Light>();

    }
 

    [Header("��ȣ�ۿ� �������� �Ǵ�")]
    public bool isWoodPanelHave = false;

    [Header("Ŭ���� ���� �Ǵ�")]
    public bool isDoorLock_Front = false;               //���� �ݱ�
    public bool isDoorLock_Bedroom = false;             //ħ�ǹ� �ݱ�
    public bool isDoorLock_LivingroomWindow = false;    //�Žǹ� �ݱ�
    public bool isDoorLock_Toilet = false;              //ȭ��� �� �ݱ�
    public bool isDoorLock_Closet = false;              //���� �ݱ�
    public bool isWindowBlockwood_Bedroom = false;      //ħ�� â�� ����
    public bool isWindowBlockwood_Livingroom = false;   //�Ž� â�� ����
    public bool isCheck_UnderBed = false;               //ħ�� �Ʒ� Ȯ��

    [Header("���� �б� �Ǵ�")]
    public bool isDia2End = false;

    [Header("����Ʈ ����")]
    public bool isLose = true;
    public float lateTime = 7f;
    public float sparkTime = 0.35f;


    public Action onDia2End;        //DialogueManager ���� �׼� �߼� �� ���⼭ ����

    public Light[] lights = new Light[3]; 

    public void Dia2End()
    {
        StartCoroutine(Dia2EndSpark_Co());
    }

    IEnumerator Dia2EndSpark_Co()
    {
        LightOff();
        while (isLose)
        {
            yield return new WaitForSeconds(lateTime);
            int a = Random.Range(1, 4);
            for(int i= 0; i < a; i++)
            {
                LightOn();
                Debug.Log("dd");
                int b = Random.Range(4, 20);
                float bb = b * 0.01f;
                yield return new WaitForSeconds(bb);
                LightOff();
                yield return new WaitForSeconds(sparkTime);
            }
            yield return null;
        }

    }

    void LightOn()
    {
        foreach (Light light in lights)
        {
            light.enabled = true;
        }
    }
    void LightOff()
    {
        foreach (Light light in lights)
        {
            light.enabled = false;
        }
    }
}
