using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI finalTimerText;

    public void UpdateTimer(float time)
    {
        timerText.text = "Time: " + Mathf.Round(time).ToString();
    }

    public void UpdateFinalTimer(float time)
    {
        finalTimerText.text = "You survived for " + Mathf.Round(time).ToString() + " seconds!";
    }

    public void UpdateLevel(int level)
    {
        levelText.text = "Level: " + level.ToString();
    }
}
