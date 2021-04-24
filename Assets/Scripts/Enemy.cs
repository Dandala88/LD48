using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float secondsPerRound;
    public Projectile prefab;
    public Vector3 projectileOffset;

    private void Start()
    {
        StartCoroutine(Fire(secondsPerRound));
    }

    private IEnumerator Fire(float seconds)
    {
        Projectile clone = Instantiate(prefab);
        clone.transform.position = transform.position;
        yield return new WaitForSeconds(seconds);
        StartCoroutine(Fire(seconds));
    }


}
