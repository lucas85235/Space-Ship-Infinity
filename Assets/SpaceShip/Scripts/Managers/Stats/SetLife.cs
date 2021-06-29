using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetLife : MonoBehaviour
{
    private void Start()
    {
        var life = GetComponent<ShipLife>();
        life.maxLife = StatsManager.i.health;
        life.Revive(0);
    }
}
