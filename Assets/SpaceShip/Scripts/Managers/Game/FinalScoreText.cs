using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreText : MonoBehaviour
{
    public Text scoreText;
    public Text moneyText;

    public void SetScore(bool isBestScore)
    {
        if (isBestScore)
        {
            scoreText.text = "Best score: " + GameManager.i.GetScore();
        }
        else scoreText.text = "Score: " + GameManager.i.GetScore();

        int value = 0;

        for (int i = 0; i < GameManager.i.GetScore(); i+=25)
        {
            value += 5;
        }

        Coin.Instance.SetMoney( value );

        if (moneyText != null)
            moneyText.text = "+" + value;        
    }
}
