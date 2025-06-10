using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject scoreBoard;
    public static bool isRestart = false;

    void Start()
    {
        if (isRestart)
        {
            mainMenuPanel.SetActive(false);
            scoreBoard.gameObject.SetActive(true);
            Time.timeScale = 1f;
            isRestart = false;
        }
        else
        {
            mainMenuPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
