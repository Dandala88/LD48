using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overlay : MonoBehaviour
{
    public Text playerHealth;
    
    private string startingPlayerHealthText = "Player Health: ";


    public void UpdatePlayerHealth(int newHealth)
    {
        playerHealth.text = startingPlayerHealthText + newHealth.ToString();
    }
}
