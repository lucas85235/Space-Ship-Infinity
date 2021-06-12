using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Score")]
    [SerializeField] private int score = 0;
    public int scoreMultiplier = 1;
    public Text scoreText;

    public static GameManager i;

    private void Awake()
    {
        i = this;

        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }

    public void AddScore(int i)
    {
        score += i * scoreMultiplier;

        if (scoreText != null)
        {
            scoreText.text = score.ToString();
        }
    }
}
