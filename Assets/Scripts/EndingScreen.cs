using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class EndingScreen : MonoBehaviour
{
    public Button restartButton;
    public Button quitButton;

    public void OnRestartClick()
    {
        Debug.Log("Clicked restart");
    }

    public void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(restartButton.gameObject);
    }

    public void Start()
    {
        GameManager.inputManager.input.SwitchCurrentActionMap("Menu");
    }

}
