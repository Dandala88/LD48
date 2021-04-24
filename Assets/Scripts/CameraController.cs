using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform follow;
    public Vector3 offset;

    private void Update()
    {
        transform.position = new Vector3(transform.position.x + offset.x, follow.transform.position.y + offset.y, transform.position.z + offset.z);
    }
}
