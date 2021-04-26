using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float secondsPerRound, activeRadius = 10f;
    public LaserProjectile prefab;
    public GameObject laserCannon, pivotPoint;
    public Vector3 projectileOffset;
    public GameObject explosionPrefab;
    public AudioClip explosionSfx;
    public float enemyLeadTarget;

    public float randomFireStagger;
    private float playerDistance;
    public bool isFiring = false;

    private Light agroLight;

    private void Start()
    {
        agroLight = GetComponentInChildren<Light>();
        agroLight.enabled = false;
        Debug.Log(agroLight);
        float rando = Random.Range(-randomFireStagger, randomFireStagger);
        secondsPerRound += rando;
    }

    private IEnumerator Fire(float seconds)
    {
        LaserProjectile clone = Instantiate(prefab, laserCannon.transform.position, laserCannon.transform.rotation);
        Vector3 leadTarget = new Vector3(GameManager.player.transform.position.x, GameManager.player.transform.position.y - enemyLeadTarget, GameManager.player.transform.position.z);
        clone.setDestination(leadTarget);
        yield return new WaitForSeconds(seconds);

        if (isFiring) {
            StartCoroutine(Fire(seconds));
        }
    }

    void Update() {
        playerDistance = Vector3.Distance(transform.position, GameManager.player.transform.position);

        if (playerDistance <= activeRadius && transform.position.y-1 <= GameManager.player.transform.position.y) {
            if (!isFiring) {
                isFiring = true;
                StartCoroutine(Fire(secondsPerRound));
            }
            pivotPoint.transform.LookAt(GameManager.player.transform);    
            agroLight.enabled = true; 
        } else {
            isFiring = false;
            agroLight.enabled = false; 
        }
    }

    public void Damage(int damage)
    {
        health -= damage;
        GameManager.scoreManager.updateScore(1);

        if(health <= 0)
        {
            GameManager.scoreManager.updateCombo(1);
            GameObject clone = Instantiate(explosionPrefab);
            clone.transform.position = transform.position;
            //GameManager.audio.PlaySoundEffect(explosionSfx);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Damage(health);
            GameManager.player.Damage(1);
            GameManager.scoreManager.resetCombo();
        }
    }

    


}
