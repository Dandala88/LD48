using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCollect : MonoBehaviour
{
    public float rotationSpeed = 1f;

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.player.health = GameManager.player.maxHealth;
            GameManager.overlay.UpdatePlayerHealth(GameManager.player.health);
            Destroy(gameObject);
        }
    }
}
