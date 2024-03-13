using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public enum Speaker
    {
        Player = 0,
        Unknown,
        Monster
    };
    public Speaker speaker = Speaker.Player;
    public bool isSpeakEnd = false;
    public const float displayTime = 2f; // �� ��簡 ȭ�鿡 ǥ�õ� �ð�
    [SerializeField] TextMeshProUGUI nameTMP;
    [SerializeField] TextMeshProUGUI dialogueTMP;
    [SerializeField] Image textBackground;

    RectTransform tmpRect;
    RectTransform thisRect;

    string player = "���ΰ� : ";
    string unknown = "�ǹ��� ���� : ";
    string monster = "??? : ";

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

    public Color playerColor = new Color32(255,102,255,255); // ���� �����
    public Color unknownColor = new Color32(051,051,204,255); // �Ķ���
    public Color monsterColor = new Color32(102,255,102,255); // �ʷϻ�
    private void Awake()
    {
        Transform child0 = transform.GetChild(0);
        Transform child1 = transform.GetChild(1);
        nameTMP = child0.GetComponent<TextMeshProUGUI>();
        dialogueTMP = child1.GetComponent<TextMeshProUGUI>();
        textBackground = GetComponent<Image>();
        startCheck = FindAnyObjectByType<StartCheck>();
        startCheck.onCheck += FirstDialogue;
        SetDialogues();
    }

    private void Start()
    {
        tmpRect = dialogueTMP.gameObject.GetComponent<RectTransform>();
        thisRect = GetComponent<RectTransform>();
        StartCoroutine(DisplayDialogues(dialogues_2, 2, 2f));      //�׽�Ʈ�� ������
    }
    private void Update()
    {
        // �ؽ�Ʈ�� ����� ������ �ʺ� ����
        AdjustWidth();
    }

    void FirstDialogue(bool isRepeat)
    {
        //ó�� ��������
        if (!isRepeat)
        {
            StartCoroutine(DisplayDialogues(dialogues_1, 1, 4.0f));
        }
    }
    private void AdjustWidth()
    {
        // �ؽ�Ʈ�� �������� ���̸� �����ɴϴ�.
        Vector2 textSize = dialogueTMP.GetPreferredValues();

        // ������Ʈ�� �ʺ� �ؽ�Ʈ�� �ʺ� �°� ����
        Vector2 curTextSize = new Vector2(textSize.x + 100, tmpRect.sizeDelta.y);
        tmpRect.sizeDelta = curTextSize;
        curTextSize.x += 50;
        thisRect.sizeDelta = curTextSize;


    }
    IEnumerator DisplayDialogues(string[] dialogues, int listNumber,float _displayTime = displayTime)
    {
        StartCoroutine(SpeakLine_HardCoding(dialogues, listNumber));
        foreach (string dialogue in dialogues)
        {
            dialogueTMP.text = dialogue; // ��縦 UI �ؽ�Ʈ�� ǥ��
            textBackground.enabled = true;

            switch (speaker) // ���� ����ϴ��� ǥ�� - �ٸ� ȭ�ڿ� �°� �����ϴ� �ڵ� �߰��ؾ���
            {
                case Speaker.Player:
                    nameTMP.text = player;
                    nameTMP.color = playerColor;
                    break;
                case Speaker.Unknown:
                    nameTMP.text = unknown;
                    nameTMP.color = unknownColor;
                    break;
                case Speaker.Monster:
                    nameTMP.text = monster;
                    nameTMP.color = monsterColor;
                    break;

            }

            // ��縦 ȭ�鿡 ǥ���� �� displayTime ���� ���
            yield return new WaitForSeconds(displayTime);

            // ��� �Ŀ� ���� ��縦 ǥ���ϱ� ���� UI �ؽ�Ʈ�� ���
            dialogueTMP.text = string.Empty;
            nameTMP.text = string.Empty;
            textBackground.enabled = false;
        }
        isSpeakEnd = false;     //��簡 ���� ���� �˸�
    }

    IEnumerator SpeakLine_HardCoding(string[] dialogues, int listNum)
    {
        isSpeakEnd = true;
        switch (listNum)
        {
            case 1:
                for (int i = 0; i < dialogues.Length; i++)
                {
                    yield return new WaitForSeconds(displayTime);
                }
                break;
            case 2:

                for (int i = 0; i < dialogues.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            speaker = Speaker.Player;
                            break;
                        case 1:
                            speaker = Speaker.Unknown;
                            break;
                        case 6:
                            speaker = Speaker.Player;
                            break;
                    }
                    yield return new WaitForSeconds(displayTime);
                }
                break;
            case 3:
                for (int i = 0; i < dialogues.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            break;
                        case 1:
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                        case 5:
                            break;
                        case 6:
                            break;
                        case 7:
                            break;

                    }
                    yield return new WaitForSeconds(displayTime);
                }
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
        }

        Debug.Log("SpeakLine_HardCoding End!!!!___!!");
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
