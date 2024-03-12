using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public string[] dialogues; // ������ ������ �迭
    public float displayTime = 2f; // �� ��簡 ȭ�鿡 ǥ�õ� �ð�

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
            dialogueText.text = dialogue; // ��縦 UI �ؽ�Ʈ�� ǥ��

            // ��縦 ȭ�鿡 ǥ���� �� displayTime ���� ���
            yield return new WaitForSeconds(displayTime);

            // ��� �Ŀ� ���� ��縦 ǥ���ϱ� ���� UI �ؽ�Ʈ�� ���
            dialogueText.text = string.Empty;
        }
    }
}
