using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public void OnMovement(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            GameManager.player.Movement(context.ReadValue<Vector2>());
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if(context.started)
        {
        }
    }
}
