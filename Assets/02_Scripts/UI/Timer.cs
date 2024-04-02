using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; // TextMesh Pro UGUI ���
    public float totalTime = 0f; // ���� �ð� (�� ����)

    private float elapsedTime; // ��� �ð�

    void Start()
    {
        timerText = GetComponent<TextMeshProUGUI>();
        elapsedTime = totalTime;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        DisplayTime(elapsedTime);
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
