using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPowerUpSpaw : MonoBehaviour
{
    [Header("Set")]
    public int spawIndex;
    public List<PowerSave> powerupList;

    private SpawManager spawManager;

    void Start()
    {
        spawManager = GetComponent<SpawManager>();
        
        foreach (var power in powerupList)
        {
            if (GetPowerUp(power.type))
            {
                spawManager.spawItems[spawIndex].items.Add(power.powerup);
            }
        }
    }

    public bool GetPowerUp(PowerType itemType)
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

    [System.Serializable]
    public struct PowerSave
    {
        public GameObject powerup;
        public PowerType type;
    }
}
