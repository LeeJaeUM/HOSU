using System.Collections;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public float displayTime = 2f; // �� ��簡 ȭ�鿡 ǥ�õ� �ð�
    public TextMeshProUGUI dialogueText;
    public string[] dialogues_1; // ������ ������ �迭
    public string[] dialogues_2; // ������ ������ �迭
    public string[] dialogues_3; // ������ ������ �迭
    public string[] dialogues_4; // ������ ������ �迭
    public string[] dialogues_5; // ������ ������ �迭
    public string[] dialogues_6; // ������ ������ �迭
    public string[] dialogues_7; // ������ ������ �迭

    public string dialogue30s = "���� ħ�� ������ ����� ��!";
    public string dialogueNoBedUse = "����? �ƹ��ϵ� �� �Ͼ�µ�?";
    public string dialogueNoCkDoor_front = "���� �������� �ᰬ����?";
    public string dialogueNoCkDoor_living = "���� �Ž� â���� �ᰬ����?";
    public string dialogueNoCkDoor_Bed = "���� �Ž� ���� �ᰬ����?";
    public string dialogueNoCkDoor_toilet = "ȭ����� Ȯ�� �߾���? ";
    public string dialogueNoCkWindow_living = "���� �Ž� â���� ���Ҿ���?";
    public string dialogueNoCkWindow_Bed = "���� ħ�� â���� ���Ҿ���?";
    public string dialogueNoCkCloset = "������ Ȯ�� �߾���?";
    public string dialogueNoCkBedUnder = "�׷���, ħ�� ���� Ȯ���߾���?";
    public string dialogueSurvive = "���� �������? �ۿ� �������߰ڴ�.";

    public string dialogueMonster = "�� �����̴�.";

    StartCheck startCheck;

    private void Awake()
    {
        dialogueText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        startCheck = FindAnyObjectByType<StartCheck>();
        startCheck.onCheck += FirstDialogue;
        SetDialogues();
    }

    void FirstDialogue(bool isRepeat)
    {
        //ó�� ��������
        if (!isRepeat)
        {
            StartCoroutine(DisplayDialogues(dialogues_1));
        }
    }

    IEnumerator DisplayDialogues(string[] dialogues)
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
    void SetDialogues()
    {
        dialogues_1 = new string[]
        {
            "�� ���� �ð��� ���� �̷��� ��ȭ�� ����?",
        };       
        dialogues_2 = new string[]
        {
            "��������?",
            "��������? �� ������? �� �����̴�.",
            "���� �ð��� ����! ������ �ʸ� ���̷�����! ",
            "���� �ڼ��Ѱ� ���߿� �� �����Ұ�! ������ ��Ƽ�� �־�!",
            "��� �ڿ� �����Ұž�! �׶������� ��Ƽ�� �־�!",
            "",
            "��������? ��������? �̰� ���� ��� �Ȱž�?",
            "��� �ڿ� ������ ���� ���̷� �´ٰ�?",
        };
        dialogues_3 = new string[]
        {
            "��������? �� ������?",
        };
        dialogues_4 = new string[]
        {
            "����� �ǰ�? ��������? �����?",
            "......"
        };
        dialogues_5 = new string[]
        {
            "������ �ȳ��ϼ���.",
            "���� ũ���������� �� �������ϼ������?",
            "12�� 26�� ��ħ�Դϴ�.",
            "���� ��ħ�� �߿�� ��ٱ濡 �� �ܴ��� �԰� ���� �����ϼ���.",
            "�̾ ���� �ҽ� ���� �帮�ڽ��ϴ�. "
        };
        dialogues_6 = new string[]
        {
            "����? �峭 ��ȭ����? ",
        };
        dialogues_7 = new string[]
        {
            "�Ű� �ް� �⵿�߽��ϴ�. Ȥ�� ���� ������ �ֽ��ϱ�?  ",
        };

    }
}
