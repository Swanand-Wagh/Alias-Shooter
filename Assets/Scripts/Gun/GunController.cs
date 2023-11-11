using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform GunHolder;
    public Gun startingGun;
    private Gun currentGun;

    void Start()
    {
        if (startingGun != null) EquipGun(startingGun);
    }

    private void EquipGun(Gun gun)
    {
        if (currentGun != null) Destroy(currentGun.gameObject);
        currentGun = Instantiate(gun, GunHolder.position, GunHolder.rotation, GunHolder);
    }

    public void ShootBullets()
    {
        if (currentGun != null)
        {
            currentGun.Shoot();
        }
    }
}
