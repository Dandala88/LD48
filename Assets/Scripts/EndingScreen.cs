using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class EndingScreen : MonoBehaviour
{
    public Text successOrFailure;
    public Text finalScore;
    
    private void Success()
    {
        successOrFailure.color = Color.green;
        successOrFailure.text = "Success";
        SetFinalScore();
    }

    private void Failure()
    {
        successOrFailure.color = Color.red;
        successOrFailure.text = "Failure";
        SetFinalScore();
    }

    private void SetFinalScore()
    {
        finalScore.text = "Final Score: " + GameManager.scoreManager.getScore();
    }

    public void EndGame(bool success)
    {
        GameManager.cameraManager.SwapCamera();
        GameManager.endingScreen.gameObject.SetActive(true);
        GameManager.overlay.gameObject.SetActive(false);
        GameManager.inputManager.SwitchMap("Menu");
        if(success)
        {
            GameManager.endingScreen.Success();
        }
        else
        {
            GameManager.endingScreen.Failure();
        }
        
        Time.timeScale = 0;
    }

}
