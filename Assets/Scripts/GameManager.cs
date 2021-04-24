using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Player player;
    public static FireCursor fireCursor;
    public static Overlay overlay;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        fireCursor = FindObjectOfType<FireCursor>();
        overlay = FindObjectOfType<Overlay>();
        Cursor.visible = false;
    }

}
