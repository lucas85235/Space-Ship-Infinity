using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [Header("Setup")]
    public PowerUpsType type;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            SelectPowerUp( other.transform );
        }
    }

    public void SelectPowerUp(Transform player)
    {
        var active = player.GetComponent<PowerUpActive>();

        switch (type)
        {
            case PowerUpsType.DoublePoints: 
                active.DoublePoints(player);
                break;
            case PowerUpsType.Healing: 
                active.Healing(player);
                break;
            case PowerUpsType.TripleShoot: 
                active.TripleShoot(player);
                break;
        }

        Destroy(gameObject);
    }
}

public enum PowerUpsType
{
    DoublePoints,
    Healing,
    TripleShoot,
}
