using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text bestScoreText;  // Text for best and current run score

    private float score = 0f;
    private float bestScore = 0f;

    void Start()
    {
        // Load the best score from PlayerPrefs
        bestScore = PlayerPrefs.GetFloat("BestScore", 0f);
        UpdateScoreUI();
    }

    void Update()
    {
        // Increase score based on time
        score += Time.deltaTime;

        // Update best score if needed
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetFloat("BestScore", bestScore);
            PlayerPrefs.Save();
        }

        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        bestScoreText.text = "Best: " + Mathf.FloorToInt(bestScore).ToString() + "\nScore: " + Mathf.FloorToInt(score).ToString();
    }

    public void ResetScore()
    {
        score = 0f;
        UpdateScoreUI();
    }

    public float GetScore()
    {
        return score;
    }
}