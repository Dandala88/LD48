using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Head : Enemy
{
    public Vector3 offsetForExplosion;
    new void Start()
    {
        float rando = Random.Range(-randomFireStagger, randomFireStagger);
        secondsPerRound += rando;
    }

    new IEnumerator Fire(float seconds)
    {
        LaserProjectile clone = Instantiate(prefab, laserCannon.transform.position, laserCannon.transform.rotation);
        Vector3 leadTarget = new Vector3(GameManager.player.transform.position.x, GameManager.player.transform.position.y - enemyLeadTarget, GameManager.player.transform.position.z);
        clone.setDestination(leadTarget);
        yield return new WaitForSeconds(seconds);

        if (isFiring) {
            StartCoroutine(Fire(seconds));
        }
    }

    new void Update() {
        playerDistance = Vector3.Distance(transform.position, GameManager.player.transform.position);

        if (playerDistance <= activeRadius && transform.position.y-1 <= GameManager.player.transform.position.y) {
            if (!isFiring) {
                isFiring = true;
                StartCoroutine(Fire(secondsPerRound));
            }
        } else {
            isFiring = false;
        }
    }


    private void OnDestroy()
    {
        GameManager.scoreManager.updateScore(500);
        GameManager.player.bossKilled = true;
    }
}
