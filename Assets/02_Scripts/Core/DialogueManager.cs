using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
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

    public Color playerColor = new Color(0.8f, 0.6f, 1f); // ���� �����
    public Color unknownColor = Color.blue; // �Ķ���
    public Color monsterColor = Color.green; // �ʷϻ�
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
        StartCoroutine(DisplayDialogues(dialogues_2, 2f));
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
            StartCoroutine(DisplayDialogues(dialogues_1, 4.0f));
        }
    }
    private void AdjustWidth()
    {
        // �ؽ�Ʈ�� �������� ���̸� �����ɴϴ�.
        Vector2 textSize = dialogueTMP.GetPreferredValues();

        // ������Ʈ�� �ʺ� �ؽ�Ʈ�� �ʺ� �°� ����
        Vector2 curTextSize = new Vector2(textSize.x + 100, tmpRect.sizeDelta.y);
        tmpRect.sizeDelta = curTextSize;
        thisRect.sizeDelta = curTextSize;


    }
    IEnumerator DisplayDialogues(string[] dialogues, float _displayTime = displayTime)
    {
        foreach (string dialogue in dialogues)
        {
            dialogueTMP.text = dialogue; // ��縦 UI �ؽ�Ʈ�� ǥ��
            nameTMP.text = player; // ���� ����ϴ��� ǥ�� - �ٸ� ȭ�ڿ� �°� �����ϴ� �ڵ� �߰��ؾ���
            textBackground.enabled = true;

            // ��縦 ȭ�鿡 ǥ���� �� displayTime ���� ���
            yield return new WaitForSeconds(displayTime);

            // ��� �Ŀ� ���� ��縦 ǥ���ϱ� ���� UI �ؽ�Ʈ�� ���
            dialogueTMP.text = string.Empty;
            nameTMP.text = string.Empty;
            textBackground.enabled = false;
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
