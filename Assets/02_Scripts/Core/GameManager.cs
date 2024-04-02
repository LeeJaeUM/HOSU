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

    InteractAction interactAction;
    public InteractAction InteractAction
    {
        get
        {
            if (interactAction == null)
                interactAction = FindAnyObjectByType<InteractAction>();
            return interactAction;
        }
    }

    FlashHead flashHead;
    public FlashHead FlashHead
    {
        get
        {
            if (flashHead == null)
                flashHead = FindAnyObjectByType<FlashHead>();
            return flashHead;
        }
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
    float[] lightIntensitys = new float[3]; //���� ������ ���� �����
    public void Dia2End()
    {
        for(int i= 0; i < lightIntensitys.Length; i++)
        {
            lightIntensitys[i] = lights[i].intensity;
        }
        StartCoroutine(Dia2EndSpark_Co());
    }

    IEnumerator Dia2EndSpark_Co()
    {
        foreach(Light light in lights)
        {
            light.intensity = 0.9f;
        }
        LightOff();
        while (isLose)
        {
            yield return new WaitForSeconds(lateTime);
            int a = Random.Range(1, 4);
            for(int i= 0; i < a; i++)
            {
                LightOn();
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
