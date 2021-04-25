using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static Player player;
    public static FireCursor fireCursor;
    public static Overlay overlay;
    public static EndingScreen endingScreen;
    public static AudioManager audioManager;
    public static ScoreManager scoreManager;
    public static CameraManager cameraManager;
    public static InputManager inputManager;

    

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        fireCursor = FindObjectOfType<FireCursor>();
        overlay = FindObjectOfType<Overlay>();
        audioManager = FindObjectOfType<AudioManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        endingScreen = FindObjectOfType<EndingScreen>();
        cameraManager = FindObjectOfType<CameraManager>();
        inputManager = FindObjectOfType<InputManager>();
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Confined;
    }

    private void Start()
    {
        endingScreen.gameObject.SetActive(false);
        inputManager.input.SwitchCurrentActionMap("Player");
    }

    

}
