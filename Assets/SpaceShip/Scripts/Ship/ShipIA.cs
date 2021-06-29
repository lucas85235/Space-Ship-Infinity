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

    [Header("Advanced")]
    public float distToOrbit = 3f;
    public float orbitSpeed = 0.5f;
    public float updateDirectionTime = 1.5f;
    private Vector3 rotateAxis = new Vector3(0, 0, 1);

    private ShipShoot m_shoot;
    private ShipLife m_life;
    private Transform m_target;
    private bool isReady = false;
    private bool canUpdateDirection = true;
    private bool canShoot = true;

    IEnumerator Start()
    {
        m_shoot = GetComponent<ShipShoot>();
        m_life = GetComponent<ShipLife>();

        while (m_target == null)
        {
            if (FindObjectOfType<Ship>() != null)
            {
                m_target = FindObjectOfType<Ship>().transform;
            }

            if (m_target == null)
            {
                yield return new WaitForSeconds(2f);
            }
        }

        SerDirection();
    }

    void Update()
    {
        if (m_life == null || !m_life.isAlive) return;

        if (iAType == IAType.Simple)
        {
            if (m_target == null) return;

            transform.position += transform.up * Time.deltaTime * moveSpeed;

            if (m_shoot != null && m_shoot.canFire)
                m_shoot.Shoot();
        }
        else
        {
            if (m_target == null) return;

            if (Vector3.Distance(transform.position, m_target.position) < distToOrbit)
            {
                transform.RotateAround(m_target.position, rotateAxis, orbitSpeed);

                if (m_shoot != null && canShoot)
                {
                    canShoot = false;
                    Invoke("CallShoot", m_shoot.fireRate);
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
        if (m_shoot.canFire)
            m_shoot.Shoot();

        canShoot = true;
    }

    private void UpdateDirection()
    {
        if (m_target == null) return;

        Vector3 targetPos = m_target.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPos - transform.position);
        canUpdateDirection = true;
    }

    private void SerDirection()
    {
        float tx = m_target.position.x * Random.Range(-precision, precision);
        float ty = m_target.position.y * Random.Range(-precision, precision);

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
