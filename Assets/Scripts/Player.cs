using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    public float drag;
    public float maxFallSpeed;
    public float recoilPercent;

    private Rigidbody rb;

    private Vector3 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(rb.velocity.x + (movement.x * movementSpeed), rb.velocity.y, rb.velocity.z + (movement.y * movementSpeed));

        if(rb.velocity.y < maxFallSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, maxFallSpeed, rb.velocity.z);
        }
    }

    public void Movement(Vector2 inputMovement)
    {
        movement = inputMovement;
    }

    public void Fire()
    {
        Vector3 recoilCalc = new Vector3(0, rb.velocity.y*recoilPercent, 0);
        rb.AddForce(recoilCalc);
    }

    private void Recoil()
    {
        if(rb.velocity.y >= 0)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);
        }
        else
        {
            Vector3 recoilCalc = new Vector3(0, rb.velocity.y*recoilPercent, 0);
        }
    }

}
