using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float fallSpeed;
    public float movementSpeed;
    public float maxSpeed;
    public float recoilPercent;
    public Lasers lasers;

    private Rigidbody rb;

    private Vector3 movement;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = movement;

        if(rb.velocity.y < maxSpeed)
        {
            rb.velocity = new Vector3(rb.velocity.x, maxSpeed, rb.velocity.z);
        }
    }

    public void Movement(Vector2 inputMovement)
    {
        movement = new Vector3(inputMovement.x * movementSpeed, rb.velocity.y, inputMovement.y * movementSpeed);
    }

    public void Fire()
    {
        Vector3 recoilCalc = new Vector3(0, rb.velocity.y*recoilPercent, 0);
        rb.AddForce(recoilCalc);
        lasers.Fire(new Vector3(Camera.main.pixelWidth/2,Camera.main.pixelHeight/2,0));//    Random.Range(0,300),Random.Range(0,300),0));
    }

}
