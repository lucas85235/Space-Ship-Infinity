using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgrade : MonoBehaviour
{
    [Header("Set")]
    public UpgradeType itemType;
    public Button buy;
    public Text priceText;
    public Text levelText;
    public Image itemImage;
    public int itemPrice;

    [Header("Popups Feedback")]
    public ConfirmBuy confirmBuy;
    public GameObject notHaveMoney;

    void Start()
    {
        foreach (var level in GetUpgradeLevels())
        {
            if (level < GetUpgrade())
                itemPrice *= 2;
        }

        if (GetCurrentUpgradeLevel() < 3)
        {
            buy.onClick.AddListener(() => TryBuy());
        }
        else
        {
            buy.interactable = false;
        }

        SetLevelText();
    }

    private void SetLevelText()
    {
        int level = GetCurrentUpgradeLevel() + 1;
        levelText.text = level < 4 ? level.ToString() : "MAX";
        priceText.text = level < 4 ? itemPrice.ToString() : "BUY";
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
        SetUpgrade(GetCurrentUpgradeLevel() + 1);

        Coin.Instance.SetMoney(-itemPrice);
        confirmBuy.Confirm = null;
        confirmBuy.gameObject.SetActive(false);

        CheckBuyAchivement();

        if (GetCurrentUpgradeLevel() < 3)
        {
            itemPrice *= 2;
            SetLevelText();
            return;
        }

        SetLevelText();
        buy.interactable = false;
    }

    public int GetCurrentUpgradeLevel()
    {
        int l = 0;

        foreach (var level in GetUpgradeLevels())
        {
            if (level == GetUpgrade())
                return l;

            l++;
        }

        return l;
    }

    public void CheckBuyAchivement()
    {
        var sLvl = StatsManager.i.speedLevels;
        var dLvl = StatsManager.i.damageLevels;
        var hLvl = StatsManager.i.speedLevels;

        if (StatsManager.i.speed == sLvl[sLvl.Length - 1] &&
            StatsManager.i.damage == dLvl[dLvl.Length - 1] &&
            StatsManager.i.health == hLvl[hLvl.Length - 1] )
        {
            SteamIMPL.i.SetAchivementBuyer();
        }
    }

    public int GetUpgrade()
    {
        switch (itemType)
        {
            case UpgradeType.Speed:
                return StatsManager.i.speed;
            case UpgradeType.Damage:
                return StatsManager.i.damage;
            case UpgradeType.Health:
                return StatsManager.i.health;
            default: return 0;
        }
    }

    public int[] GetUpgradeLevels()
    {
        switch (itemType)
        {
            case UpgradeType.Speed:
                return StatsManager.i.speedLevels;
            case UpgradeType.Damage:
                return StatsManager.i.damageLevels;
            case UpgradeType.Health:
                return StatsManager.i.healthLevels;
            default: return null;
        }
    }

    public void SetUpgrade(int index)
    {
        switch (itemType)
        {
            case UpgradeType.Speed:
                StatsManager.i.speed = StatsManager.i.speedLevels[index];
                break;
            case UpgradeType.Damage:
                StatsManager.i.damage = StatsManager.i.damageLevels[index];
                break;
            case UpgradeType.Health:
                StatsManager.i.health = StatsManager.i.healthLevels[index];
                break;
        }

        PlayerPrefs.Save();
    }
}

public enum UpgradeType
{
    Speed,
    Damage,
    Health,
}
