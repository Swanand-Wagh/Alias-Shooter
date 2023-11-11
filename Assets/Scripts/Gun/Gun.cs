using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform muzzle;
    public Projectile bullet;
    public float msBetweenShots = 100f;
    public float bulletSpeed = 35f;
    private float nextShotTime;

    public void Shoot()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000; // cuz we want to convert ms to seconds
            Projectile newBullet = Instantiate(bullet, muzzle.position, muzzle.rotation);
            newBullet.SetBulletSpeed(bulletSpeed);
        }
    }
}
