using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
            GameManager.player.Fire();
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

    public void OnRestart(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            Debug.Log(GameManager.trackKeeper.startingscreen);
            if(GameManager.trackKeeper.startingscreen)
            {
                
                GameManager.trackKeeper.startingscreen = false;
                GameManager.overlay.gameObject.SetActive(true);
                GameManager.endingScreen.gameObject.SetActive(false);
                GameManager.startingScreen.gameObject.SetActive(false);
                GameManager.inputManager.SwitchMap("Player");
            }
            GameManager.cameraManager.SwapCamera();
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
    }

    public void OnQuit(InputAction.CallbackContext context)
    {
        if(context.started)
        {
            Application.Quit();
        }
    }

    public void SwitchMap(string actionMap)
    {
        GetComponent<PlayerInput>().SwitchCurrentActionMap(actionMap);
    }

}
