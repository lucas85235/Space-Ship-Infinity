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

    // speed initial 2
    // speed lv 2 - 3
    // speed lv 3 - 4
    // speed lv max - 5

    public int damage
    {
        get => PlayerPrefs.GetInt(damageKey);
        set => PlayerPrefs.SetInt(damageKey, value);
    }

    // damage initial 15
    // damage lv 2 - 20
    // damage lv 3 - 25
    // damage lv max - 30

    public int health
    {
        get => PlayerPrefs.GetInt(healthKey);
        set => PlayerPrefs.SetInt(healthKey, value);
    }

    // health initial 60
    // health lv 2 - 80
    // health lv 3 - 100
    // health lv max - 120

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

        PlayerPrefs.Save();
    }
}
