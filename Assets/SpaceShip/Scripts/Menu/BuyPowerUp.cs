using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyPowerUp : MonoBehaviour
{
    [Header("Set")]
    public PowerType itemType;
    public Button buy;
    public Text priceText;
    public Image itemImage;
    public int itemPrice;

    [Header("Popups Feedback")]
    public ConfirmBuy confirmBuy;
    public GameObject notHaveMoney;

    void Start()
    {
        SetPowerBuy();
    }

    private void SetPowerBuy()
    {
        if (!GetPowerUp())
        {
            priceText.text = itemPrice.ToString();
            buy.onClick.AddListener(() => TryBuy());
        }
        else
        {
            priceText.text = "BUY";
            buy.interactable = false;
        }
    }

    private void TryBuy()
    {
        if (Coin.Instance.money >= itemPrice)
        {
            confirmBuy.gameObject.SetActive(true);
            confirmBuy.Confirm = null;
            confirmBuy.Confirm = ConfirmBuy;
        }
        else notHaveMoney.SetActive(true);
    }

    public void ConfirmBuy()
    {
        SetPowerUp(true);

        Coin.Instance.SetMoney(-itemPrice);
        confirmBuy.Confirm = null;
        confirmBuy.gameObject.SetActive(false);
        buy.interactable = false;
        priceText.text = "BUY";

        CheckBuyAchivement();
    }

    public void CheckBuyAchivement()
    {
        if (StatsManager.i.powerDp && StatsManager.i.powerTs && StatsManager.i.powerH)
        {
            SteamIMPL.i.SetAchivementBuyer();
        }
    }

    public bool GetPowerUp()
    {
        switch (itemType)
        {
            case PowerType.PowerDP:
                return StatsManager.i.powerDp;
            case PowerType.PowerTS:
                return StatsManager.i.powerTs;
            case PowerType.PowerH:
                return StatsManager.i.powerH;
            default: return false;
        }
    }

    public void SetPowerUp(bool state)
    {
        switch (itemType)
        {
            case PowerType.PowerDP:
                StatsManager.i.powerDp = state;
                break;
            case PowerType.PowerTS:
                StatsManager.i.powerTs = state;
                break;
            case PowerType.PowerH:
                StatsManager.i.powerH = state;
                break;
        }

        PlayerPrefs.Save();
    }
}

public enum PowerType
{
    PowerTS,
    PowerDP,
    PowerH,
}