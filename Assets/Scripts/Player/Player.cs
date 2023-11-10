using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class Player : MonoBehaviour
{
    private PlayerController controller;
    public float speed = 5f;

    void Start()
    {
        controller = GetComponent<PlayerController>();
    }

    void Update()
    {
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * speed; // velocity = direction * speed
        controller.SetVelocity(moveVelocity);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.collider != null && hit.collider.CompareTag("Floor"))
            {
                Vector3 hitPoint = hit.point;
                controller.LookAt(hitPoint);
            }
        }
    }
}
