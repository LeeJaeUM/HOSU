using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartSceneInteract : MonoBehaviour
{
    public string nextSceneName = "LoadingScene";
    public TextMeshProUGUI title;
    public float temp = 0.1f;
    public float endTime = 4f;
    public float testno = 0;

    public Color imageColor;
    public Color textColor;
    public GameObject obj;

    public TextMeshProUGUI start;
    public TextMeshProUGUI exit;

    private void Awake()
    {
        obj = GameObject.Find("Titel_TMP");
        title = obj.GetComponent<TextMeshProUGUI>();
        StartCoroutine(Start_Co());
    }
    IEnumerator Start_Co()
    {
        yield return new WaitForSeconds(4);
        while (temp < endTime)
        {

            float normalizedTime = temp / endTime;
            testno = normalizedTime;
            temp += Time.deltaTime;
            Debug.Log(testno);

            //텍스트 알파값 투명하게 만들기
            textColor = title.color;
            textColor.a = Mathf.Lerp(0f, 1f, normalizedTime);
            title.color = textColor;

            //imageColor = start.color;
            //imageColor.a = Mathf.Lerp(0f, 1f, normalizedTime);
            start.color = textColor;
            exit.color = textColor;
            yield return null;
        }
    }
    public void StartGame()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    public void EndGame()
    {
        // End the game
        Application.Quit();
    }
}
