using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class SteamIMPL : MonoBehaviour
{
    private string m_BEGINNER = "BEGINNER_100_POINTS";
    private string m_SURVIVOR = "SURVIVOR_500_POINTS";
    private string m_EXPERIENT = "EXPERIENT_1000_POINTS";
    private string m_HUNTER = "HUNTER_10";
    private string m_DESTROYER = "DESTROYER_50";
    private string m_ANNIHILATOR = "ANNIHILATOR_200";
    private string m_BUYER = "BUYER";
    private string m_BEATER = "BEATER";

    public static SteamIMPL i;

    private void Awake()
    {
        i = this;

        if (!SteamManager.Initialized) return;
        Debug.Log(SteamFriends.GetPersonaName());
    }

    private void SetAchivement(string achivement_id)
    {
        try
        {
            SteamUserStats.SetAchievement(achivement_id);
            SteamUserStats.StoreStats();            
        }
        catch (System.Exception) { throw; }
    }

    public void SetAchivementBeginner() => SetAchivement(m_BEGINNER);
    public void SetAchivementSurvivor() => SetAchivement(m_SURVIVOR);
    public void SetAchivementExperient() => SetAchivement(m_EXPERIENT);
    public void SetAchivementHunter() => SetAchivement(m_HUNTER);
    public void SetAchivementDestroyer() => SetAchivement(m_DESTROYER);
    public void SetAchivementAnnihilator() => SetAchivement(m_ANNIHILATOR);
    public void SetAchivementBuyer() => SetAchivement(m_BUYER);
    public void SetAchivementBeater() => SetAchivement(m_BEATER);
}
