using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Ship : MonoBehaviour
{
    [Header("Stats")]
    public float speed = 2f;
    public float damage;
    public float health;

    private ShipShoot shoot;

    void Start()
    {
        shoot = GetComponent<ShipShoot>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && shoot.canFire)
        {
            shoot.canFire = false;
            shoot.Shoot();
        }
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    public void Move()
    {
        Vector3 move = new Vector3( Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") );
        transform.position += move * Time.deltaTime * speed;
    }

    public void Rotate()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint( mousePosition );

        Vector2 direction = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y
        );

        transform.up = direction;
    }
}
