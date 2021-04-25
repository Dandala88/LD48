using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float secondsPerRound;
    public LaserProjectile prefab;
    public Vector3 projectileOffset;
    public GameObject explosionPrefab;
    public AudioClip explosionSfx;

    public float randomFireStagger;

    private void Start()
    {
        float rando = Random.Range(-randomFireStagger, randomFireStagger);
        secondsPerRound += rando;
        StartCoroutine(Fire(secondsPerRound));
    }

    private IEnumerator Fire(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        LaserProjectile clone = Instantiate(prefab, transform.position, transform.rotation);
        clone.setDestination(GameManager.player.transform.position);
        StartCoroutine(Fire(seconds));
    }

    public void Damage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            GameObject clone = Instantiate(explosionPrefab);
            clone.transform.position = transform.position;
            //GameManager.audio.PlaySoundEffect(explosionSfx);
            Destroy(gameObject);
        }
    }

    


}
