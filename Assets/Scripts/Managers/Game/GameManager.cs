using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    [Header("Score")]
    public int scoreMultiplier = 1;
    public Text scoreText;

    [Header("Score")]
    public UnityEvent GameOverEvent;

    private int score = 0;
    private bool gameOver = false;

    public static GameManager i;

    private void Awake()
    {
        i = this;

        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }

        if (GameOverEvent == null)
            GameOverEvent = new UnityEvent();
    }

    public int GetScore() => score;

    public void AddScore(int i)
    {
        if (gameOver) return;

        score += i * scoreMultiplier;

        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    public void GameOver()
    {
        gameOver = true;
        GameOverEvent.Invoke();
        Time.timeScale = 0.1f;

        var scoreText = FindObjectOfType<FinalScoreText>();

        if (score > StatsManager.i.bestScore)
        {
            // check achivements


            StatsManager.i.bestScore = score;
            PlayerPrefs.Save();

            if (scoreText != null)
                scoreText.SetScore(true);
            
            return;
        }

        if (scoreText != null)
            scoreText.SetScore(false);
    }
}
