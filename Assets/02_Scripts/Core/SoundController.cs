using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public Transform listener; // ��� ����� ��ġ (�ַ� ī�޶�)
    private AudioSource audioSource;
    public float maxVolumeDistance = 15f; // �ִ� ������ ���� �Ÿ�

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (listener != null)
        {
            float distance = Vector3.Distance(transform.position, listener.position);
            float volume = 1f; // �ʱ� ����

            // �Ҹ��� �ִ� �Ÿ��� ��� ���
            if (distance > maxVolumeDistance)
            {
                volume = 0f; // �Ҹ��� �鸮�� ����
            }
            else
            {
                // �Ҹ��� �ִ� �Ÿ� ���� �ִ� ���, �Ÿ��� ���� ���� ����
                volume = 1f - (distance / maxVolumeDistance);
            }

            audioSource.volume = volume; // ���� ����
        }
    }
}
