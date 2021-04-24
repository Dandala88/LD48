using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static Player player;
    public static FireCursor fireCursor;

    private void Awake()
    {
        player = FindObjectOfType<Player>();
        fireCursor = FindObjectOfType<FireCursor>();
        Cursor.visible = false;
    }

}
