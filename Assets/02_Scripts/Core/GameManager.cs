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

    [Header("상호작용 가능한지 판단")]
    public bool isWoodPanelHave = false;

    [Header("클리어 조건 판단")]
    public bool isDoorLock_Bedroom = false;
    public bool isDoorLock_LivingroomWindow = false;
    public bool isWindowBlockwood_Bedroom = false;
    public bool isWindowBlockwood_Livingroom = false;

}
