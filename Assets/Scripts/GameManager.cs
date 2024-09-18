using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int level;
    public float timer;
    [SerializeField] TilesSelector tilesSelector;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] int[] levelTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        UpdateTimer();
        if (level < levelTimer.Length && timer > levelTimer[level])
        {
            level += 1;
            tilesSelector.tilesInterval -= level / 10f;
            UpdateLevel();
        }
    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void UpdateTimer()
    {
        timerText.text = "Time: " + Mathf.Round(timer).ToString();
    }

    public void UpdateLevel()
    {
        levelText.text = "Level: " + level.ToString();
    }
}
