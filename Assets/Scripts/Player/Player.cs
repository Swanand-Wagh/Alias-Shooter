using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GunController))]
public class Player : LivingEntity
{
    private PlayerController playerController;
    private GunController gunController;

    public float speed = 5f;

    protected override void Start()
    {
        base.Start(); // call LivingEntity Start()
        playerController = GetComponent<PlayerController>();
        gunController = GetComponent<GunController>();
    }

    void Update()
    {
        // Movement Input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * speed; // velocity = direction * speed
        playerController.SetVelocity(moveVelocity);

        // LookAt Input
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.collider != null && hit.collider.CompareTag("Floor"))
            {
                playerController.LookAt(hit.point);
            }
        }

        // Weapon Input
        if (Input.GetMouseButton(0))
        {
            gunController.ShootBullets();
        }
    }
}
