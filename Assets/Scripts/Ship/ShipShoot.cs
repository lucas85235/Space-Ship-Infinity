using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShoot : MonoBehaviour
{
    [Header("Shoot")]
    public float fireRate = 0.6f;
    public float bulletSpeed = 700f;
    public Transform bulletSpawPoint;
    public Rigidbody2D bulletPrefab;
    
    [HideInInspector] public bool canFire = true;

    public void Shoot()
    {
        canFire = false;

        Rigidbody2D bullet = Instantiate(bulletPrefab, bulletSpawPoint.position, bulletSpawPoint.rotation);
        bullet.AddForce( bulletSpawPoint.up * bulletSpeed, ForceMode2D.Force );

        Invoke("FireRate", fireRate);
    }

    public void FireRate() => canFire = true;
}
