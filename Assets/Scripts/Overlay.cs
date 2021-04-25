using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overlay : MonoBehaviour
{
    public Text playerHealth, scoreText, comboText;

    public Image fillBar;
    
    private string startingPlayerHealthText = "";

    public void UpdateScoreInfo(int score, int combo) {
        string fmt = "000000000";
        scoreText.text = score.ToString(fmt);

        comboText.text = "x" + combo.ToString();
    }

    public void UpdatePlayerHealth(int newHealth)
    {
        playerHealth.text = startingPlayerHealthText + newHealth.ToString();

        float healthPercent = (float)GameManager.player.health / (float)GameManager.player.maxHealth;
        fillBar.fillAmount = healthPercent;
    }
}
