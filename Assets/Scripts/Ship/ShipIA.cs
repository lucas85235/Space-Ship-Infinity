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
    public float moveSpeed = 1.2f;

    [Range(1f, 2f)]
    public float precision = 1.1f;

    [Header("Status")]
    public float distToOrbit = 3f;
    public float orbitSpeed = 0.5f;
    public float updateDirectionTime = 1.5f;
    public Vector3 rotateAxis = new Vector3(0, 0, 1);

    private ShipShoot shoot;
    private Transform target;
    private bool isReady = false;
    private bool canUpdateDirection = true;
    private bool canShoot = true;

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

            transform.position += transform.up * Time.deltaTime * moveSpeed;

            if (shoot != null && shoot.canFire)
                shoot.Shoot();
        }
        else
        {
            if (target == null) return;

            if (Vector3.Distance(transform.position, target.position) < distToOrbit)
            {
                transform.RotateAround(target.position, rotateAxis, orbitSpeed);

                if (shoot != null && canShoot)
                {
                    canShoot = false;
                    Invoke("CallShoot", shoot.fireRate);
                }
            }
            else
            {
                if (canUpdateDirection)
                {
                    canUpdateDirection = false;
                    Invoke("UpdateDirection", updateDirectionTime);
                }

                transform.position += transform.up * Time.deltaTime * moveSpeed;
            }
        }
    }

    private void CallShoot()
    {
        if (shoot.canFire)
            shoot.Shoot();

        canShoot = true;
    }

    private void UpdateDirection()
    {
        if (target == null) return;

        Vector3 targetPos = target.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPos - transform.position);
        canUpdateDirection = true;
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
