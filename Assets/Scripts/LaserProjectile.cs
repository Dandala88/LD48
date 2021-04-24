using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    public float ProjectileSpeed = 100f;
    public float lifeSpan = 0.5f;
    //private float lifeTime = 0;
    public Vector3 destination;
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(destination);
            
        Destroy(this, lifeSpan);
    }

    void Update() {
        // lifeTime += Time.deltaTime;
        // if (lifeTime > lifeSpan) ;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, destination, ProjectileSpeed*Time.fixedDeltaTime);
        if (Vector3.Distance(transform.position, destination) < .1) {
            
            Destroy(this);
        }

        transform.LookAt(destination);
    }

    void Destroy() {
        foreach (Transform child in this.transform) {
            Debug.Log("Destruction Emitent");
            Destroy(child.gameObject);
        }
    }

    public void setDestination(Vector3 destination) {
        this.destination = destination;
        transform.LookAt(destination);
    }
}
