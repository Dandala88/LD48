using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCursor : MonoBehaviour
{
    public void Move(Vector2 inputMove)
    {
        transform.position = new Vector2(transform.position.x + inputMove.x, transform.position.y + inputMove.y);
    }
}
