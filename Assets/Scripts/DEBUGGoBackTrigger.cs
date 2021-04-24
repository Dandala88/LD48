using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DEBUGGoBackTrigger : MonoBehaviour
{
    private Vector3 starting;

    private void Start()
    {
        starting = GameManager.player.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.player.transform.position = starting;
        }
    }
}
