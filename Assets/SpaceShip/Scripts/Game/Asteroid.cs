using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Header("Status")]
    public float speed = 1.2f;

    [Range(1f, 2f)]
    public float precision = 1.1f;
    public bool useLife = true;

    [Header("Debug")]
    public Transform target;

    private bool m_isReady = false;
    private ShipLife m_life;

    IEnumerator Start()
    {
        m_life = GetComponent<ShipLife>();

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
        if (useLife)
        {
            if (m_life == null || !m_life.isAlive) return;
        }
        
        if (m_isReady)
        {
            transform.position += transform.up * Time.deltaTime * speed;
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
        m_isReady = true;
    }
}
