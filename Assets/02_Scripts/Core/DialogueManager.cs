using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public enum Speaker
    {
        Player = 0,
        Unknown,
        Monster,
        News,
        Police
    };
    public Speaker speaker = Speaker.Player;
    public bool isSpeakEnd = false;
    public const float displayTime = 2f; // �� ��簡 ȭ�鿡 ǥ�õ� �ð�
    [SerializeField] TextMeshProUGUI nameTMP;
    [SerializeField] TextMeshProUGUI dialogueTMP;
    [SerializeField] Image textBackground;

    RectTransform dTMPRect;
    RectTransform nameTMPRect;
    RectTransform thisRect;

    string player = " ���ΰ� : ";
    string unknown = " �ǹ��� ���� : ";
    string monster = " ??? : ";
    string news = " ���� : ";
    string police = " ���� : ";

    public string[] dialogues_1; // ������ ������ �迭
    public string[] dialogues_2; // ������ ������ �迭
    public string[] dialogues_3; // ������ ������ �迭
    public string[] dialogues_4; // ������ ������ �迭
    public string[] dialogues_5; // ������ ������ �迭
    public string[] dialogues_6; // ������ ������ �迭
    public string[] dialogues_7; // ������ ������ �迭
    public string[] dialogues_8; // ������ ������ �迭

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
    public string dialogueStart = " 'E �� ������ �Ͼ��.' ";

    public string dialogueMonster = "�� �����̴�.";

    StartCheck startCheck;

    public Color playerColor = new Color32(0, 255, 0, 255); // �ʷ�
    public Color unknownColor = new Color32(0, 0, 204, 255); // �Ķ���
    public Color monsterColor = new Color32(102, 51, 153, 255); // ����    

    public bool isTutorialDialogueOn = false; //EŰ �Է� �� Ʃ�丮��� ��� ���� ���� bool����

    PlayerInputActions inputActions;
    private void Awake()
    {
        inputActions = new PlayerInputActions();
        Transform child0 = transform.GetChild(0);
        Transform child1 = transform.GetChild(1);
        nameTMP = child0.GetComponent<TextMeshProUGUI>();
        dialogueTMP = child1.GetComponent<TextMeshProUGUI>();
        textBackground = GetComponent<Image>();
        startCheck = FindAnyObjectByType<StartCheck>();
        startCheck.onCheck += FirstDialogue;
        //�⺻ ��� ����
        SetDialogues();
    }
    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Interact.performed += OnInteract;
    }
    private void OnDisable()
    {
        inputActions.Player.Interact.performed -= OnInteract;
        inputActions.Player.Disable();
    }
    private void OnInteract(InputAction.CallbackContext obj)    //EŰ �Է� �� Ʃ�丮��� ��� ���� ����
    {
       if(isTutorialDialogueOn)
            HideDialogue();
    }

    private void Start()
    {
        dTMPRect = dialogueTMP.gameObject.GetComponent<RectTransform>();
        nameTMPRect = nameTMP.gameObject.GetComponent<RectTransform>();
        thisRect = GetComponent<RectTransform>();

        textBackground.enabled = false; //���� �� �� �޹�� �Ⱥ��̰� ó��

        StartCoroutine(StartDiaLogue_Co());
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


    IEnumerator StartDiaLogue_Co()
    {
        yield return new WaitForSeconds(10f);
        isTutorialDialogueOn = true;
        LoadDialogue(dialogueStart, Speaker.Player);
    }
    public void LoadDialogue(string dialogue, Speaker _speaker)
    {
        dialogueTMP.text = dialogue; // ��縦 UI �ؽ�Ʈ�� ǥ��
        textBackground.enabled = true;

        SpeakerSelector(_speaker);
    }

    public void HideDialogue()
    {
        // ��� �Ŀ� ���� ��縦 ǥ���ϱ� ���� UI �ؽ�Ʈ�� ���
        dialogueTMP.text = string.Empty;
        nameTMP.text = string.Empty;
        textBackground.enabled = false;
        isTutorialDialogueOn = false;
    }

    IEnumerator Dia2_Co()
    {
        yield return new WaitForSeconds(2);
        while (isSpeakEnd)      //��� ���϶� ����
        {
            yield return null;
        }
        //2��° ��� ���� �� ����
        GameManager.Inst.isDia2End = true;
        GameManager.Inst.onDia2End?.Invoke();
    }

    private void AdjustWidth()
    {
        // �ؽ�Ʈ�� �������� ���̸� �����ɴϴ�.
        Vector2 textSize = dialogueTMP.GetPreferredValues();
        Vector2 nameSize = nameTMP.GetPreferredValues();

        // ������Ʈ�� �ʺ� �ؽ�Ʈ�� �ʺ� �°� ����
        Vector2 curTextSize = new Vector2(textSize.x + 200, 50);
        Vector2 curNameSize = new Vector2(nameSize.x + 120, 50);
        ///Vector2 curTextSize = new Vector2(textSize.x + 120, dTMPRect.sizeDelta.y);
        //Vector2 curNameSize = new Vector2(nameSize.x + 50, dTMPRect.sizeDelta.y);
        dTMPRect.sizeDelta = curTextSize;
        nameTMPRect.sizeDelta = curNameSize;
        curTextSize.x += 50;
        thisRect.sizeDelta = curTextSize;


    }
    IEnumerator DisplayDialogues(string[] dialogues, int listNumber,float _displayTime = displayTime)
    {
        isSpeakEnd = true;
        StartCoroutine(SpeakLine_HardCoding(dialogues, listNumber));
        foreach (string dialogue in dialogues)
        {
            dialogueTMP.text = dialogue; // ��縦 UI �ؽ�Ʈ�� ǥ��
            textBackground.enabled = true;

            SpeakerSelector(speaker);
            // ��縦 ȭ�鿡 ǥ���� �� displayTime ���� ���
            yield return new WaitForSeconds(displayTime);

            // ��� �Ŀ� ���� ��縦 ǥ���ϱ� ���� UI �ؽ�Ʈ�� ���
            dialogueTMP.text = string.Empty;
            nameTMP.text = string.Empty;
            textBackground.enabled = false;
        }
        isSpeakEnd = false;     //��簡 ���� ���� �˸�
    }

    void SpeakerSelector(Speaker speaker)
    {

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
            case Speaker.News:
                nameTMP.text = news;
                nameTMP.color = Color.white;
                break;
            case Speaker.Police:
                nameTMP.text = police;
                nameTMP.color = Color.white;
                break;
        }
    }

    IEnumerator SpeakLine_HardCoding(string[] dialogues, int listNum)
    {
        switch (listNum)
        {
            case 1:
                for (int i = 0; i < dialogues.Length; i++)
                {
                    speaker = Speaker.Player;
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
                    speaker = Speaker.Unknown;
                    yield return new WaitForSeconds(displayTime);
                }
                break;
            case 4:
                for (int i = 0; i < dialogues.Length; i++)
                {
                    speaker = Speaker.Player;
                    yield return new WaitForSeconds(displayTime);
                }
                break;
            case 5:
                for (int i = 0; i < dialogues.Length; i++)
                {
                    speaker = Speaker.News;
                    yield return new WaitForSeconds(displayTime);
                }
                break;
            case 6:
                for (int i = 0; i < dialogues.Length; i++)
                {
                    speaker = Speaker.Player;
                    yield return new WaitForSeconds(displayTime);
                }
                break;
            case 7:
                for (int i = 0; i < dialogues.Length; i++)
                {
                    speaker = Speaker.Police;
                    yield return new WaitForSeconds(displayTime);
                }
                break;
            case 8:
                for (int i = 0; i < dialogues.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            speaker = Speaker.Player;
                            break;
                        case 1:
                            speaker = Speaker.Monster;
                            break;
                        case 2:
                            speaker = Speaker.Unknown;
                            break;
                        case 3:
                            speaker = Speaker.Player;
                            break;
                    }
                    yield return new WaitForSeconds(displayTime);
                }
                break;
        }

        Debug.Log("SpeakLine_HardCoding End!!!!___!!");
    }
    void SetDialogues()
    {
        dialogues_1 = new string[]
        {
            "...",
            "�� ���� �ð��� ���� �̷��� ��ȭ�� ����?"
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
            "��������?", 
            "�� ������?"
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
        dialogues_8 = new string[]
        {
            "�Ű� �ް� �⵿�߽��ϴ�. Ȥ�� ���� ������ �ֽ��ϱ�?  ",
            "���� ���ʹ� ���� ���������T  ",
            "�ǹ��� ��������Դϴ�. �׽�Ʈ �Դ��׽�Ʈ �� ��簡 ��� �����ΰ�??",
            "�ٽ� ���� ���ΰ� �ʴٶ�ư�  ",
        };
    }

    public void SpeakDialogue(int index)
    {
        switch (index)
        {
            case 1:
                StartCoroutine(DisplayDialogues(dialogues_1, 1, 5));
                break;
            case 2:
                StartCoroutine(DisplayDialogues(dialogues_2, 2));
                StartCoroutine(Dia2_Co());
                break;
            case 3:
                StartCoroutine(DisplayDialogues(dialogues_3, 3));
                break;
            case 4:
                StartCoroutine(DisplayDialogues(dialogues_4, 4));
                break;
            case 5:
                StartCoroutine(DisplayDialogues(dialogues_5, 5));
                break;
            case 6:
                StartCoroutine(DisplayDialogues(dialogues_6, 6));
                break;
            case 7:
                StartCoroutine(DisplayDialogues(dialogues_7, 7));
                break;
            case 8:
                StartCoroutine(DisplayDialogues(dialogues_8, 8));
                break;
        }
    }


}
