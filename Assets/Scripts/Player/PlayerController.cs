using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    private Vector3 velocity;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    public void SetVelocity(Vector3 velocity)
    {
        this.velocity = velocity;
    }

    void FixedUpdate()
    {
        playerRigidbody.MovePosition(this.transform.position + velocity * Time.fixedDeltaTime);
    }
}
