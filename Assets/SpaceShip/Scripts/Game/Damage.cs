using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int damage = 10;
    public DamageLayer damageLayer;
    public bool destroy = false;
}

public enum DamageLayer
{
    Player,
    Enemy
}
