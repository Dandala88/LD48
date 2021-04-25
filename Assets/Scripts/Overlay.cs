using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overlay : MonoBehaviour
{
    public Text playerHealth;

    public Image fillBar;
    
    private string startingPlayerHealthText = "";


    public void UpdatePlayerHealth(int newHealth)
    {
        playerHealth.text = startingPlayerHealthText + newHealth.ToString();

        float healthPercent = (float)GameManager.player.health / (float)GameManager.player.maxHealth;
        fillBar.fillAmount = healthPercent;
    }
}
