using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashHead : MonoBehaviour
{
    public static FlashHead Inst;
    private void Awake()
    {
        if (Inst != null)
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
    private void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
