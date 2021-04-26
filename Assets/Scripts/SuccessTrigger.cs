using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager.endingScreen.EndGame(true);
        }
    }
}
