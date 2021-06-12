using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDamage : MonoBehaviour
{
    private void Start()
    {
        var damage = GetComponent<Damage>();
        damage.damage = StatsManager.i.damage;
    }
}
