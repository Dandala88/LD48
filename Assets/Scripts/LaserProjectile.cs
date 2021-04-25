using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserProjectile : MonoBehaviour
{
    public int power;
    public float ProjectileSpeed = 100f;
    public float lifeSpan = 0.5f;
    //private float lifeTime = 0;
    public Vector3 destination;
    public AudioClip fireSound;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(destination);
            
        Destroy(gameObject, lifeSpan);
        foreach (Transform child in this.transform) {
            Destroy(child.gameObject, lifeSpan);
        }
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


    public void setDestination(Vector3 destination) {
        this.destination = destination;
        transform.LookAt(destination);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().Damage(power);
        }

        if(other.CompareTag("Player"))
        {
            other.GetComponent<Player>().Damage(power);
        }
    }
}