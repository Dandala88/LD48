using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    public float ProjectileSpeed = .8f;
    public Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, destination, ProjectileSpeed*Time.deltaTime);
        if (Vector3.Distance(transform.position, destination) < .01) {
            Destroy(this);
        }
    }
}
