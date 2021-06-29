using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpActive : MonoBehaviour
{
    [Header("Setup")]
    public float powerUpTime = 10f;

    public void DoublePoints(Transform player)
    {
        StartCoroutine( DoublePointsRoutine(player) );
    }

    private IEnumerator DoublePointsRoutine(Transform player)
    {
        Debug.Log("Active PowerUp DoublePoints");
        GameManager.i.scoreMultiplier = 2;

        yield return new WaitForSeconds(powerUpTime);
        GameManager.i.scoreMultiplier = 1;
    }

    public void Healing(Transform player)
    {
        StartCoroutine( HealingRoutine(player) );
    }

    private IEnumerator HealingRoutine(Transform player)
    {
        Debug.Log("Active PowerUp Healing");

        var life = player.GetComponent<ShipLife>();
        life.SetLife(life.maxLife);

        yield return null;
    }

    public void TripleShoot(Transform player)
    {
        Debug.Log("Active PowerUp TripleShoot");
        StartCoroutine( TripleShootRoutine(player) );
    }

    private IEnumerator TripleShootRoutine(Transform player)
    {
        Debug.Log("Active PowerUp TripleShoot");

        var shoot = player.GetComponent<ShipShoot>();
        shoot.activeTripleShoot = true;

        yield return new WaitForSeconds(powerUpTime);
        shoot.activeTripleShoot = false;
    }
}
