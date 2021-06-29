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
    
    [Header("Audio")]
    public AudioClip audioShoot;
    private AudioSource m_audioSource;

    [Header("Triple Shoot")]
    public Transform[] bulletSpawPoints;

    [HideInInspector] public bool canFire = true;
    [HideInInspector] public bool activeTripleShoot = false;

    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    public void Shoot()
    {
        canFire = false;

        if (audioShoot != null)
            m_audioSource.PlayOneShot(audioShoot);

        if (activeTripleShoot)
        {
            TripleShoot();
            return;
        }

        Rigidbody2D bullet = Instantiate(bulletPrefab, bulletSpawPoint.position, bulletSpawPoint.rotation);
        bullet.AddForce( bulletSpawPoint.up * bulletSpeed, ForceMode2D.Force );

        Invoke("FireRate", fireRate);
    }

    public void TripleShoot()
    {
        foreach (var point in bulletSpawPoints)
        {
            Rigidbody2D bullet = Instantiate(bulletPrefab, point.position, point.rotation);
            bullet.AddForce( point.up * bulletSpeed, ForceMode2D.Force );
        }

        Invoke("FireRate", fireRate);
    }

    public void FireRate() => canFire = true;
}
