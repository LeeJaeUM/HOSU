using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public Transform listener; // 듣는 사람의 위치 (주로 카메라)
    private AudioSource audioSource;
    public float maxVolumeDistance = 15f; // 최대 볼륨을 갖는 거리

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (listener != null)
        {
            float distance = Vector3.Distance(transform.position, listener.position);
            float volume = 1f; // 초기 볼륨

            // 소리가 최대 거리를 벗어난 경우
            if (distance > maxVolumeDistance)
            {
                volume = 0f; // 소리가 들리지 않음
            }
            else
            {
                // 소리가 최대 거리 내에 있는 경우, 거리에 따라 볼륨 조절
                volume = 1f - (distance / maxVolumeDistance);
            }

            audioSource.volume = volume; // 볼륨 설정
        }
    }
}
