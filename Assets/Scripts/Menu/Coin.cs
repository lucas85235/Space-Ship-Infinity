using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    [Header("Money")]
    public int money;
    public Text moneyText;
    private string moneySaveKey = "money";

    public static Coin Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if ( !PlayerPrefs.HasKey(moneySaveKey) )
        {
            PlayerPrefs.SetInt(moneySaveKey, 0);
            PlayerPrefs.Save();
        }

        SetMoney();
    }

    public void SetMoney( int increment = 0 )
    {
        if (increment != 0)
        {
            money += increment;
            PlayerPrefs.SetInt(moneySaveKey, money);
            PlayerPrefs.Save();
        }

        money = PlayerPrefs.GetInt( moneySaveKey );
        moneyText.text = money.ToString();
    }
}
