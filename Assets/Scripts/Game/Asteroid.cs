using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [Header("Status")]
    public float speed = 1.2f;

    [Range(1f, 2f)]
    public float precision = 1.1f;

    [Header("Debug")]
    public Transform target;

    private bool isReady = false;

    IEnumerator Start()
    {
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
        if (isReady)
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
        isReady = true;
    }
}
