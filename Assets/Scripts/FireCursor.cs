using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCursor : MonoBehaviour
{
    public Canvas canvas;
    public void Move(Vector2 inputMove)
    {
        var newX = Mathf.Clamp(transform.position.x + inputMove.x,0,10000);
        var newY = transform.position.y + inputMove.y;
        transform.position = new Vector2(newX, newY);
    }
}
