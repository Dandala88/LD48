using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCursor : MonoBehaviour
{
    public Canvas canvas;

    void Start() {
        canvas = GetComponentInParent<Canvas>();
    }
    public void Move(Vector2 inputMove)
    {
        var newX = Mathf.Clamp(transform.position.x + inputMove.x,0,canvas.pixelRect.width);
        var newY = Mathf.Clamp(transform.position.y + inputMove.y,0,canvas.pixelRect.height);
        transform.position = new Vector2(newX, newY);
    }
}
