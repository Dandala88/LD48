using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed;
    public Vector3 dragPercent;
    public float maxFallSpeed;
    public float minFallSpeed;
    public float hangtime;
    public Vector3 recoil;
    public Lasers lasers;

    private Rigidbody rb;

    private Vector3 movement;

    private Vector3 tParam;

    private bool hanging;

    private float hangingTimer = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(hangingTimer >= hangtime)
        {
            rb.useGravity = true;
        }
    }
    private void FixedUpdate()
    {
        hangingTimer += Time.fixedDeltaTime;
        rb.AddForce((movement * movementSpeed));
        rb.velocity = new Vector3(rb.velocity.x * dragPercent.x, Mathf.Clamp(rb.velocity.y, maxFallSpeed, minFallSpeed), rb.velocity.z * dragPercent.z);
    }

    public void Movement(Vector2 inputMovement)
    {
        movement = new Vector3(inputMovement.x, 0, inputMovement.y);
    }

    public void Fire()
    {
        rb.AddForce(recoil);
        lasers.Fire(new Vector3(GameManager.fireCursor.transform.position.x,GameManager.fireCursor.transform.position.y,0));//    Random.Range(0,300),Random.Range(0,300),0));
    }

}
