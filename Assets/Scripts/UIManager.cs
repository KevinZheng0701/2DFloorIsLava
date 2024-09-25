using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI levelText;

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void UpdateTimer(float time)
    {
        timerText.text = "Time: " + Mathf.Round(time).ToString();
    }

    public void UpdateLevel(int level)
    {
        levelText.text = "Level: " + level.ToString();
    }
}
