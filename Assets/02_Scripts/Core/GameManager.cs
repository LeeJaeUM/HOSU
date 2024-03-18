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
    public Action onDia2End;        //DialogueManager ���� �׼� �߼� �� ���⼭ ����

}
