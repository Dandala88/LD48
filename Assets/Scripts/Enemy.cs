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

    public float randomFireStagger;
    private float playerDistance;
    public bool isFiring = false;

    private void Start()
    {
        float rando = Random.Range(-randomFireStagger, randomFireStagger);
        secondsPerRound += rando;
    }

    private IEnumerator Fire(float seconds)
    {
        LaserProjectile clone = Instantiate(prefab, laserCannon.transform.position, laserCannon.transform.rotation);
        clone.setDestination(GameManager.player.transform.position);
        yield return new WaitForSeconds(seconds);

        if (isFiring) {
            StartCoroutine(Fire(seconds));
        }
    }

    void Update() {
        playerDistance = Vector3.Distance(transform.position, GameManager.player.transform.position);

        if (playerDistance <= activeRadius) {
            if (!isFiring) {
                isFiring = true;
                Debug.Log("bruh");
                StartCoroutine(Fire(secondsPerRound));
            }
            pivotPoint.transform.LookAt(GameManager.player.transform);     
        } else {
            isFiring = false;
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

    


}
