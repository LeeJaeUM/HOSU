using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartSceneInteract : MonoBehaviour
{
    public string nextSceneName = "LoadingScene";

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
