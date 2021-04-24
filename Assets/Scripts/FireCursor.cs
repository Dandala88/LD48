using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCursor : MonoBehaviour
{
    private float scale = 1;
    public void Move(Vector2 inputMove)
    {
        transform.position = new Vector2(transform.position.x + inputMove.x * scale, transform.position.y + inputMove.y * scale);
    }
}
