using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MadeInHouse.Translate;

public class FinalScoreText : MonoBehaviour
{
    public Text scoreText;
    public Text moneyText;

    public void SetScore(bool isBestScore)
    {
        if (isBestScore)
        {
            scoreText.text = LanguageManager.GetKeyValue("best_score") + " " + GameManager.i.GetScore();
        }
        else scoreText.text = LanguageManager.GetKeyValue("score") + " "  + GameManager.i.GetScore();

        int value = 0;

        for (int i = 0; i < GameManager.i.GetScore(); i+=15)
        {
            value += 5;
        }

        Coin.Instance.SetMoney( value );

        if (moneyText != null)
            moneyText.text = "+" + value;        
    }
}
