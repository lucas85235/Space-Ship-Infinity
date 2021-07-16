using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamBridge : MonoBehaviour
{
    public int destroyedShips
    {
        get => PlayerPrefs.GetInt(destroyedSave);
        set => PlayerPrefs.SetInt(destroyedSave, value);
    }

    private string destroyedSave = "DestroyShips";

    private void Awake()
    {
        InitSaveKeys();
    }

    private void InitSaveKeys()
    {
        if ( !PlayerPrefs.HasKey(destroyedSave) )
            destroyedShips = 0;

        PlayerPrefs.Save();
    }

    public void SetDestroyShipsAchviment()
    {
        destroyedShips += 1;
        PlayerPrefs.Save();

        if (destroyedShips >= 10) SteamIMPL.i.SetAchivementHunter();
        if (destroyedShips >= 50) SteamIMPL.i.SetAchivementDestroyer();
        if (destroyedShips >= 200) SteamIMPL.i.SetAchivementAnnihilator();
    }
}
