using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public const float displayTime = 2f; // 각 대사가 화면에 표시될 시간
    [SerializeField] TextMeshProUGUI dialogueText;
    [SerializeField] Image textBackground;

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

    private void Awake()
    {
        dialogueText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        textBackground = transform.GetChild(0).GetComponent<Image>();
        startCheck = FindAnyObjectByType<StartCheck>();
        startCheck.onCheck += FirstDialogue;
        SetDialogues();
    }

    void FirstDialogue(bool isRepeat)
    {
        //처음 눌렀을때
        if (!isRepeat)
        {
            StartCoroutine(DisplayDialogues(dialogues_1, 4.0f));
        }
    }

    IEnumerator DisplayDialogues(string[] dialogues, float _displayTime = displayTime)
    {
        foreach (string dialogue in dialogues)
        {
            dialogueText.text = dialogue; // 대사를 UI 텍스트에 표시
            textBackground.enabled = true;

            // 대사를 화면에 표시한 후 displayTime 동안 대기
            yield return new WaitForSeconds(displayTime);

            // 대기 후에 다음 대사를 표시하기 위해 UI 텍스트를 비움
            dialogueText.text = string.Empty;
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
