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
    public const float displayTime = 2f; // 각 대사가 화면에 표시될 시간
    [SerializeField] TextMeshProUGUI nameTMP;
    [SerializeField] TextMeshProUGUI dialogueTMP;
    [SerializeField] Image textBackground;

    RectTransform dTMPRect;
    RectTransform nameTMPRect;
    RectTransform thisRect;

    string player = " 주인공 : ";
    string unknown = " 의문의 여성 : ";
    string monster = " ??? : ";
    string news = " 뉴스 : ";
    string police = " 경찰 : ";

    public string[] dialogues_1; // 대사들을 저장한 배열
    public string[] dialogues_2; // 대사들을 저장한 배열
    public string[] dialogues_3; // 대사들을 저장한 배열
    public string[] dialogues_4; // 대사들을 저장한 배열
    public string[] dialogues_5; // 대사들을 저장한 배열
    public string[] dialogues_6; // 대사들을 저장한 배열
    public string[] dialogues_7; // 대사들을 저장한 배열
    public string[] dialogues_8; // 대사들을 저장한 배열

    public string dialogue30s = "빨리 침대 밑으로 숨어야 해!";
    public string dialogueNoBedUse = "뭐지? 아무일도 안 일어났는데?";
    public string dialogueNoCkDoor_front = "내가 현관문을 잠갔던가?";
    public string dialogueNoCkDoor_living = "내가 거실 창문을 잠갔던가?";
    public string dialogueNoCkDoor_Bed = "내가 거실 문을 잠갔던가?";
    public string dialogueNoCkDoor_toilet = "화장실은 확인 했었나? ";
    public string dialogueNoCkWindow_living = "내가 거실 창문을 막았었나?";
    public string dialogueNoCkWindow_Bed = "내가 침실 창문을 막았었나?";
    public string dialogueNoCkCloset = "옷장은 확인 했었나?";
    public string dialogueNoCkBedUnder = "그런데, 침대 밑은 확인했었나?";
    public string dialogueSurvive = "이제 사라졌나? 밖에 나가봐야겠다.";
    public string dialogueStart = " 'E 를 눌러서 일어나자.' ";

    public string dialogueMonster = "휴 다행이다.";

    StartCheck startCheck;

    public Color playerColor = new Color32(0, 255, 0, 255); // 초록
    public Color unknownColor = new Color32(0, 0, 204, 255); // 파란색
    public Color monsterColor = new Color32(102, 51, 153, 255); // 보라    

    public bool isTutorialDialogueOn = false; //E키 입력 시 튜토리얼용 대사 끄기 위한 bool변수

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
        //기본 대사 지정
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
    private void OnInteract(InputAction.CallbackContext obj)    //E키 입력 시 튜토리얼용 대사 끄기 위함
    {
       if(isTutorialDialogueOn)
            HideDialogue();
    }

    private void Start()
    {
        dTMPRect = dialogueTMP.gameObject.GetComponent<RectTransform>();
        nameTMPRect = nameTMP.gameObject.GetComponent<RectTransform>();
        thisRect = GetComponent<RectTransform>();

        textBackground.enabled = false; //시작 시 글 뒷배경 안보이게 처리

        StartCoroutine(StartDiaLogue_Co());
    }
    private void Update()
    {
        // 텍스트가 변경될 때마다 너비를 조정
        AdjustWidth();
    }

    void FirstDialogue(bool isRepeat)
    {
        //처음 눌렀을때
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
        dialogueTMP.text = dialogue; // 대사를 UI 텍스트에 표시
        textBackground.enabled = true;

        SpeakerSelector(_speaker);
    }

    public void HideDialogue()
    {
        // 대기 후에 다음 대사를 표시하기 위해 UI 텍스트를 비움
        dialogueTMP.text = string.Empty;
        nameTMP.text = string.Empty;
        textBackground.enabled = false;
        isTutorialDialogueOn = false;
    }

    IEnumerator Dia2_Co()
    {
        yield return new WaitForSeconds(2);
        while (isSpeakEnd)      //대사 중일때 루프
        {
            yield return null;
        }
        //2번째 대사 종료 후 실행
        GameManager.Inst.isDia2End = true;
        GameManager.Inst.onDia2End?.Invoke();
    }

    private void AdjustWidth()
    {
        // 텍스트가 보여지는 길이를 가져옵니다.
        Vector2 textSize = dialogueTMP.GetPreferredValues();
        Vector2 nameSize = nameTMP.GetPreferredValues();

        // 오브젝트의 너비를 텍스트의 너비에 맞게 조정
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
            dialogueTMP.text = dialogue; // 대사를 UI 텍스트에 표시
            textBackground.enabled = true;

            SpeakerSelector(speaker);
            // 대사를 화면에 표시한 후 displayTime 동안 대기
            yield return new WaitForSeconds(displayTime);

            // 대기 후에 다음 대사를 표시하기 위해 UI 텍스트를 비움
            dialogueTMP.text = string.Empty;
            nameTMP.text = string.Empty;
            textBackground.enabled = false;
        }
        isSpeakEnd = false;     //대사가 끝난 것을 알림
    }

    void SpeakerSelector(Speaker speaker)
    {

        switch (speaker) // 누가 대사하는지 표시 - 다만 화자에 맞게 변경하는 코드 추가해야함
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
            "이 늦은 시간에 누가 이렇게 전화를 하지?"
        };       
        dialogues_2 = new string[]
        {
            "여보세요?",
            "여보세요? 너 괜찮아? 휴 다행이다.",
            "지금 시간이 없어! 누군가 너를 죽이려고해! ",
            "내가 자세한건 나중에 다 설명할게! 집에서 버티고 있어!",
            "삼분 뒤에 도착할거야! 그때까지만 버티고 있어!",
            "",
            "여보세요? 여보세요? 이게 뭐가 어떻게 된거야?",
            "삼분 뒤에 누군가 나를 죽이러 온다고?",
        };
        dialogues_3 = new string[]
        {
            "여보세요?", 
            "너 괜찮아?"
        };
        dialogues_4 = new string[]
        {
            "사라진 건가? 여보세요? 저기요?",
            "......"
        };
        dialogues_5 = new string[]
        {
            "여러분 안녕하세요.",
            "어제 크리스마스는 잘 마무리하셨을까요?",
            "12월 26일 아침입니다.",
            "오늘 아침도 추우니 출근길에 옷 단단히 입고 감기 조심하세요.",
            "이어서 다음 소식 전달 드리겠습니다. "
        };
        dialogues_6 = new string[]
        {
            "뭐지? 장난 전화였나? ",
        };
        dialogues_7 = new string[]
        {
            "신고를 받고 출동했습니다. 혹시 무슨 문제가 있습니까?  ",
        };
        dialogues_8 = new string[]
        {
            "신고를 받고 출동했습니다. 혹시 무슨 문제가 있습니까?  ",
            "나는 몬스터다 나는 몬스투투투퉅  ",
            "의문의 여성대사입니다. 테스트 입니테스트 얘 대사가 길면 문제인가??",
            "다시 나다 주인공 너다라아가  ",
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
