using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text gameOverText;
    private ScoreManager scoreManager;
    public Text scoreBoard;

    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOverUI()
    {
        Time.timeScale = 0f;

        scoreBoard.gameObject.SetActive(false);

        gameOverPanel.SetActive(true);

        float bestScore = PlayerPrefs.GetFloat("BestScore", 0f);
        float currentScore = scoreManager.GetScore();

        gameOverText.text = "Game Over\nBest: " + Mathf.FloorToInt(bestScore).ToString() + "\nScore: " + Mathf.FloorToInt(currentScore).ToString();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        MenuManager.isRestart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}