using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }
 
    private void Dia2End()
    {
        throw new NotImplementedException();
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
    public Action onDia2End;        //DialogueManager 에서 액션 발송 후 여기서 실행

}
