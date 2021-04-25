using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FireCursor : MonoBehaviour
{
    private Canvas canvas;
    public float mouseSensitivity = 1f;

    public bool mousePos2CursPos;

    void Start() {
        canvas = GetComponentInParent<Canvas>();
    }
    public void Move(Vector2 inputMove)
    {
        var newX = Mathf.Clamp(transform.position.x + inputMove.x * mouseSensitivity ,0,canvas.pixelRect.width);
        var newY = Mathf.Clamp(transform.position.y + inputMove.y * mouseSensitivity,0,canvas.pixelRect.height);
        transform.position = new Vector2(newX, newY);
        if(mousePos2CursPos)
        {
            Mouse.current.WarpCursorPosition(transform.position);
        }
    }
}
