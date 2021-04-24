using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBackTrigger : MonoBehaviour
{
    private Vector3 startingPosition;
    private void Start()
    {
        startingPosition = GameManager.player.transform.position;
    }

    private void OnTriggerEnter()
    {
        GameManager.player.transform.position = startingPosition;
    }
}
