using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float bulletSpeed;

    public void SetBulletSpeed(float speed)
    {
        bulletSpeed = speed;
    }

    void Update()
    {
        this.transform.Translate(this.transform.forward * bulletSpeed * Time.deltaTime);
    }
}
