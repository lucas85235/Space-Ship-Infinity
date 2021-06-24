using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [Header("Money")]
    public Text moneyText;
    private string moneySaveKey = "money";
    public int money { get; protected set; }

    public static Coin Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if ( !PlayerPrefs.HasKey(moneySaveKey) )
        {
            PlayerPrefs.SetInt(moneySaveKey, 1000);
            PlayerPrefs.Save();
        }

        SetMoney(0);
    }

    public void SetMoney( int increment )
    {
        if (increment != 0)
        {
            money += increment;
            PlayerPrefs.SetInt(moneySaveKey, money);
            PlayerPrefs.Save();
        }

        money = PlayerPrefs.GetInt( moneySaveKey );

        if (moneyText != null)
            moneyText.text = money.ToString();
    }
}
