using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    public Vector3 dragPercent;
    public float maxFallSpeed;
    public float recoilPercent;
    public Lasers lasers;

    private Rigidbody rb;

    private Vector3 movement;

    private Vector3 tParam;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.AddForce((movement * movementSpeed));
        rb.velocity = new Vector3(rb.velocity.x * dragPercent.x, rb.velocity.y, rb.velocity.z * dragPercent.z);
        //rb.velocity = new Vector3(rb.velocity.x + (movement.x * movementSpeed), rb.velocity.y, rb.velocity.z + (movement.y * movementSpeed));

        if(rb.velocity.y < maxFallSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, maxFallSpeed, rb.velocity.z);
        }
    }

    public void Movement(Vector2 inputMovement)
    {
        movement = new Vector3(inputMovement.x, 0, inputMovement.y);
    }

    public void Fire()
    {
        Vector3 recoilCalc = new Vector3(0, rb.velocity.y*recoilPercent, 0);
        rb.AddForce(recoilCalc);
        lasers.Fire(new Vector3(GameManager.fireCursor.transform.position.x,GameManager.fireCursor.transform.position.y,0));//    Random.Range(0,300),Random.Range(0,300),0));
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
