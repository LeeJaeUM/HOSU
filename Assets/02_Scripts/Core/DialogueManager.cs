using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public const float displayTime = 2f; // 각 대사가 화면에 표시될 시간
    [SerializeField] TextMeshProUGUI nameTMP;
    [SerializeField] TextMeshProUGUI dialogueTMP;
    [SerializeField] Image textBackground;

    RectTransform tmpRect;
    RectTransform thisRect;

    string player = "주인공 : ";
    string unknown = "의문의 여성 : ";
    string monster = "??? : ";

    public string[] dialogues_1; // 대사들을 저장한 배열
    public string[] dialogues_2; // 대사들을 저장한 배열
    public string[] dialogues_3; // 대사들을 저장한 배열
    public string[] dialogues_4; // 대사들을 저장한 배열
    public string[] dialogues_5; // 대사들을 저장한 배열
    public string[] dialogues_6; // 대사들을 저장한 배열
    public string[] dialogues_7; // 대사들을 저장한 배열

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

    public string dialogueMonster = "휴 다행이다.";

    StartCheck startCheck;

    public Color playerColor = new Color(0.8f, 0.6f, 1f); // 밝은 보라색
    public Color unknownColor = Color.blue; // 파란색
    public Color monsterColor = Color.green; // 초록색
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
        // 텍스트가 변경될 때마다 너비를 조정
        AdjustWidth();
    }

    void FirstDialogue(bool isRepeat)
    {
        //처음 눌렀을때
        if (!isRepeat)
        {
            StartCoroutine(DisplayDialogues(dialogues_1, 4.0f));
        }
    }
    private void AdjustWidth()
    {
        // 텍스트가 보여지는 길이를 가져옵니다.
        Vector2 textSize = dialogueTMP.GetPreferredValues();

        // 오브젝트의 너비를 텍스트의 너비에 맞게 조정
        Vector2 curTextSize = new Vector2(textSize.x + 100, tmpRect.sizeDelta.y);
        tmpRect.sizeDelta = curTextSize;
        thisRect.sizeDelta = curTextSize;


    }
    IEnumerator DisplayDialogues(string[] dialogues, float _displayTime = displayTime)
    {
        foreach (string dialogue in dialogues)
        {
            dialogueTMP.text = dialogue; // 대사를 UI 텍스트에 표시
            nameTMP.text = player; // 누가 대사하는지 표시 - 다만 화자에 맞게 변경하는 코드 추가해야함
            textBackground.enabled = true;

            // 대사를 화면에 표시한 후 displayTime 동안 대기
            yield return new WaitForSeconds(displayTime);

            // 대기 후에 다음 대사를 표시하기 위해 UI 텍스트를 비움
            dialogueTMP.text = string.Empty;
            nameTMP.text = string.Empty;
            textBackground.enabled = false;
        }
    }
    void SetDialogues()
    {
        dialogues_1 = new string[]
        {
            "이 늦은 시간에 누가 이렇게 전화를 하지?",
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
            "여보세요? 너 괜찮아?",
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

    }
}
