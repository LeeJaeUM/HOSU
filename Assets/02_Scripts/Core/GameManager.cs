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
            //DontDestroyOnLoad(gameObject);
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

    GoBedUI gobedUI;
    public GoBedUI GobedUI
    {
        get
        {
            if (gobedUI == null)
                gobedUI = FindAnyObjectByType<GoBedUI>();
            return gobedUI;
        }
    }

    [Header("상호작용 가능한지 판단")]
    public bool isWoodPanelHave = false;

    [Header("클리어 조건 판단")]
    public bool isDoorLock_Front = false;               //정문 닫기
    public bool isDoorLock_Bedroom = false;             //침실문 닫기
    public bool isDoorLock_LivingroomWindow = false;    //거실문 닫기
    public bool isDoorLock_Toilet = false;              //화장실 문 닫기
    public bool isDoorLock_Closet = false;              //옷장 닫기
    public bool isWindowBlockwood_Bedroom = false;      //침실 창문 방지
    public bool isWindowBlockwood_Livingroom = false;   //거실 창문 방지
    public bool isCheck_UnderBed = false;               //침대 아래 확인

    [Header("게임 분기 판단")]
    public bool isDia2End = false;
    public bool isGameClear = false;

    [Header("라이트 관련")]
    public bool isLose = true;
    public float lateTime = 7f;
    public float sparkTime = 0.35f;


    public Action onDia2End;        //DialogueManager 에서 액션 발송 후 여기서 실행
    public Action onGameClear;      //침대 밑에 숨고 조건 클리어 시 Bed에서 사용

    public Light[] lights = new Light[3];
    float[] lightIntensitys = new float[3]; //기존 전등의 세기 저장용
    public void Dia2End()
    {
        // 정전 시작 후 모든 조건 비활성화
        isDoorLock_Front = false;
        isDoorLock_Bedroom = false;
        isDoorLock_LivingroomWindow = false;
        isDoorLock_Toilet = false;
        isDoorLock_Closet = false;
        isWindowBlockwood_Bedroom = false;
        isWindowBlockwood_Livingroom = false;
        isCheck_UnderBed = false;

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
