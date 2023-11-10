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

    public void LookAt(Vector3 hitPoint)
    {
        this.transform.LookAt(new Vector3(hitPoint.x, this.transform.localScale.y, hitPoint.z));
    }

    void FixedUpdate()
    {
        // position + velocity * time = movement
        playerRigidbody.MovePosition(this.transform.position + velocity * Time.fixedDeltaTime);
    }
}
