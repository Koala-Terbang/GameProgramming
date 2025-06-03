using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;

    void Start()
    {
        // Pause the game at the start
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        // Hide the menu
        mainMenuPanel.SetActive(false);

        // Resume the game
        Time.timeScale = 1f;
    }

    public void Quit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
