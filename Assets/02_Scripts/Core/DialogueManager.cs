using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] dialogues; // 대사들을 저장한 배열
    public float displayTime = 2f; // 각 대사가 화면에 표시될 시간

    private void Awake()
    {
        dialogueText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
       // StartCoroutine(DisplayDialogues());
    }

    IEnumerator DisplayDialogues()
    {
        foreach (string dialogue in dialogues)
        {
            dialogueText.text = dialogue; // 대사를 UI 텍스트에 표시

            // 대사를 화면에 표시한 후 displayTime 동안 대기
            yield return new WaitForSeconds(displayTime);

            // 대기 후에 다음 대사를 표시하기 위해 UI 텍스트를 비움
            dialogueText.text = string.Empty;
        }
    }
}
