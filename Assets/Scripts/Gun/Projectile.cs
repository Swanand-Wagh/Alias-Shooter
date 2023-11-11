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
        float bulletDistance = bulletSpeed * Time.deltaTime;
        this.transform.Translate(Vector3.right * bulletDistance);
        CheckBulletCollision(bulletDistance);
    }

    private void CheckBulletCollision(float dist)
    {
        Ray ray = new Ray(this.transform.position, transform.right);
        if (Physics.Raycast(ray, out RaycastHit hit, dist, LayerMask.GetMask("Enemy"), QueryTriggerInteraction.Collide))
        {
            Destroy(this.gameObject);
        }
    }
}
