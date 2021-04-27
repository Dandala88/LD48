using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingScreen : MonoBehaviour
{
    private void Start()
    {
        if(GameManager.trackKeeper.startingscreen)
        {
            
            GameManager.inputManager.SwitchMap("Menu");
            Time.timeScale = 0;
            GameManager.overlay.gameObject.SetActive(false);
            GameManager.endingScreen.gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
