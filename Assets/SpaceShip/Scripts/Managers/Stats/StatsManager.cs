using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    public int speed 
    {
        get => PlayerPrefs.GetInt(speedKey);
        set => PlayerPrefs.SetInt(speedKey, value);
    }

    public int[] speedLevels = new int[4] { 2, 3, 4, 5 };

    public int damage
    {
        get => PlayerPrefs.GetInt(damageKey);
        set => PlayerPrefs.SetInt(damageKey, value);
    }

    public int[] damageLevels = new int[4] { 15, 20, 25, 30 };

    public int health
    {
        get => PlayerPrefs.GetInt(healthKey);
        set => PlayerPrefs.SetInt(healthKey, value);
    }

    public int[] healthLevels = new int[4] { 60, 80, 100, 120 };

    private string speedKey = "speed";
    private string damageKey = "damage";
    private string healthKey = "health";

    public bool powerTs
    {
        get => PlayerPrefs.GetInt(power_1) == 0 ? false : true;
        set => PlayerPrefs.SetInt(power_1, value == false ? 0 : 1);
    }

    public bool powerDp
    {
        get => PlayerPrefs.GetInt(power_2) == 0 ? false : true;
        set => PlayerPrefs.SetInt(power_2, value == false ? 0 : 1);
    }

    public bool powerH
    {
        get => PlayerPrefs.GetInt(power_3) == 0 ? false : true;
        set => PlayerPrefs.SetInt(power_3, value == false ? 0 : 1);
    }

    private string power_1 = "power_1";
    private string power_2 = "power_2";
    private string power_3 = "power_3";

    public int bestScore
    {
        get => PlayerPrefs.GetInt(scoreKey);
        set => PlayerPrefs.SetInt(scoreKey, value);
    }

    private string scoreKey = "scoreKey";


    public static StatsManager i;

    private void Awake()
    {
        i = this;
        InitSaveKeys();
    }

    public void InitSaveKeys()
    {
        if ( !PlayerPrefs.HasKey(speedKey) )
            speed = 2;

        if ( !PlayerPrefs.HasKey(damageKey) )
            damage = 15;
        
        if ( !PlayerPrefs.HasKey(healthKey) )
            health = 60;
        
        if ( !PlayerPrefs.HasKey(power_1) )
            powerTs = false;

        if ( !PlayerPrefs.HasKey(power_2) )
            powerDp = false;
        
        if ( !PlayerPrefs.HasKey(power_3) )
            powerH = false;

        if ( !PlayerPrefs.HasKey(scoreKey) )
            bestScore = 0;

        PlayerPrefs.Save();
    }
}
