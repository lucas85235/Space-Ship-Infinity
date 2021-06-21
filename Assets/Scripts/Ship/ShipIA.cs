using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipIA : MonoBehaviour
{
    // vai ficar em uma area/trajetoria circular em volta do player
        // onde vai começar a atirar

    // vai simplesmente em direção ao jogador 
        // atirando ou 
        // de forma kamikazi

    [Header("Setup")]
    public IAType iAType = IAType.Simple;

    [Header("Status")]
    public float speed = 1.2f;

    [Range(1f, 2f)]
    public float precision = 1.1f;

    private ShipShoot shoot;

    private Transform target;
    private bool isReady = false;

    IEnumerator Start()
    {
        shoot = GetComponent<ShipShoot>();

        while (target == null)
        {
            if (FindObjectOfType<Ship>() != null)
            {
                target = FindObjectOfType<Ship>().transform;
            }
        
            if (target == null)
            {
                yield return new WaitForSeconds(2f);
            }
        }

        SerDirection();
    }

    void Update()
    {
        if (iAType == IAType.Simple)
        {
            if (target == null) return;
            
            transform.position += transform.up * Time.deltaTime * speed;

            if (shoot != null && shoot.canFire)
                shoot.Shoot();
        }
        else
        {
            Debug.LogError("IAType.Advanced Not Implemented");
        }
    }

    private void SerDirection()
    {
        float tx = target.position.x * Random.Range(-precision, precision);
        float ty = target.position.y * Random.Range(-precision, precision);

        Vector2 direction = new Vector2();

        direction.x = tx - transform.position.x;
        direction.y = ty - transform.position.y;

        transform.up = direction;            
    }

    public enum IAType
    {
        Simple,
        Advanced
    }
}
