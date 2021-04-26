using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Camera menuCamera;
    public Camera gameplayCamera;

    private void Start()
    {
        menuCamera.enabled = false;
        gameplayCamera.enabled = true;
    }

    public void SwapCamera()
    {
        if(gameplayCamera.enabled)
        {
            gameplayCamera.enabled = false;
            menuCamera.enabled = true;
        }
        else
        {
            gameplayCamera.enabled = true;
            menuCamera.enabled = false;
        }
    }
}
