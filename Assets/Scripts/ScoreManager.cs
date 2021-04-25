using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    private int combo = 0, score = 0;

    // Update is called once per frame
    public void updateScore(int amount) {
        score += amount * combo;
        GameManager.overlay.UpdateScoreInfo(score, combo);
    }

    public void updateCombo(int amount) {
        combo += amount;
        GameManager.overlay.UpdateScoreInfo(score, combo);
    }

    public void resetCombo() {
        combo = 0;
    }

    public int getScore() {
        return score;
    }

    public int getCombo() {
        return combo;
    }
}
