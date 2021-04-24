using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    //public delegate void OnFireAction();
    //public static event OnFireAction InputFire;


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
            GameManager.player.Fire();
            //InputFire();
        }
    }

    public void OnMoveCursor(InputAction.CallbackContext context)
    {
        if(context.performed)
        {

            Vector2 inputToSend = context.ReadValue<Vector2>();
            //inputToSend = new Vector2(Mathf.Clamp(inputToSend.x, -1.0f, 1.0f), Mathf.Clamp(inputToSend.y, -1.0f, 1.0f));
            GameManager.fireCursor.Move(inputToSend);
        }
    }

}
