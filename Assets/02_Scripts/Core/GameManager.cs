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
    }

    [Header("��ȣ�ۿ� �������� �Ǵ�")]
    public bool isWoodPanelHave = false;

    [Header("Ŭ���� ���� �Ǵ�")]
    public bool isDoorLock_Bedroom = false;
    public bool isDoorLock_LivingroomWindow = false;
    public bool isWindowBlockwood_Bedroom = false;
    public bool isWindowBlockwood_Livingroom = false;

}
