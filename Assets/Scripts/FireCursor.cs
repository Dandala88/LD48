using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCursor : MonoBehaviour
{
    private Canvas canvas;
    public float mouseSensitivity = 1f;

    void Start() {
        canvas = GetComponentInParent<Canvas>();
    }
    public void Move(Vector2 inputMove)
    {
        var newX = Mathf.Clamp(transform.position.x + inputMove.x * mouseSensitivity ,0,canvas.pixelRect.width);
        var newY = Mathf.Clamp(transform.position.y + inputMove.y * mouseSensitivity,0,canvas.pixelRect.height);
        transform.position = new Vector2(newX, newY);
    }
}
