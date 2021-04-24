using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPivot : MonoBehaviour
{
    public float maxFireDistance = 10f;

    private Vector3 target;
    private Vector3 cursorPos;

    private void Start()
    {
        cursorPos = GameManager.fireCursor.transform.position;
        target = Camera.main.ScreenToWorldPoint(new Vector3(cursorPos.x, cursorPos.y, maxFireDistance));
        StartCoroutine(LogPerSeconds(3));
    }

    private void FixedUpdate()
    {
        cursorPos = GameManager.fireCursor.transform.position;
        target = Camera.main.ScreenToWorldPoint(new Vector3(cursorPos.x, cursorPos.y, maxFireDistance));
        transform.position = target;
    }

    private IEnumerator LogPerSeconds(float seconds)
    {
        
        Debug.Log(cursorPos);
        Debug.Log(target);
        yield return new WaitForSeconds(seconds);
        StartCoroutine(LogPerSeconds(3));
    }
}
