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

    [Header("Shoot")]
    public float fireRate = 0.3f;
    public float bulletSpeed = 700f;
    public Transform bulletSpawPoint;
    public Rigidbody2D bulletPrefab;
    private bool canFire = true;

    [Header("Life")]
    public float maxLife = 100f;
    public Slider lifeBar;
    private float currentLife;
    
    [Header("Die Event")]
    public UnityEvent OnDie;


    void Start()
    {
        if (OnDie == null)
            OnDie = new UnityEvent();

        currentLife = maxLife;
        lifeBar.maxValue = maxLife;
        lifeBar.value = maxLife;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && canFire)
        {
            canFire = false;
            Shoot();
        }

        if (Input.GetMouseButtonDown(1))
        {
            SetLife(-10);
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

    public void Shoot()
    {
        Rigidbody2D bullet = Instantiate(bulletPrefab, bulletSpawPoint.position, bulletSpawPoint.rotation);
        bullet.AddForce( bulletSpawPoint.up * bulletSpeed, ForceMode2D.Force );

        Invoke("FireRate", fireRate);
    }

    public void FireRate() => canFire = true;

    public void SetLife(int increment)
    {
        currentLife += increment;

        if (currentLife > maxLife) 
            currentLife = maxLife;

        if (currentLife < 1)
        {
            this.enabled = false;
            OnDie.Invoke();
        }

        lifeBar.value = currentLife;
    }

    public void Revive(float time)
    {
        Invoke("Revive", time);
    }

    private void Revive()
    {
        currentLife = maxLife;
        lifeBar.maxValue = maxLife;
        lifeBar.value = maxLife;

        this.enabled = true;
        this.gameObject.SetActive(true);
    }
}
