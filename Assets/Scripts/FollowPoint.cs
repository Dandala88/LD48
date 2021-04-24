using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPoint : MonoBehaviour
{
    public Vector3 fractionOffset;
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(GameManager.player.transform.position.x * fractionOffset.x, GameManager.player.transform.position.y * fractionOffset.y, GameManager.player.transform.position.z * fractionOffset.z);
    }
}
