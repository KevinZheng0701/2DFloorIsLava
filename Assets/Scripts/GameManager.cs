using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int level; // Level of the game
    public float timer; // Timer to keep track how long the players survived
    public TilesManager tilesManager; // Reference to the tiles
    public UIManager uiManager; // Reference to the ui manager
    public int[] levelTimer; // Array of times that once the time pass the level gets harder

    // Update is called once per frame
    void Update()
    {
        // Update the time
        timer += Time.deltaTime;
        uiManager.UpdateTimer(timer);
        // Move to the next level once the current time reach the time needed for the enxt level
        if (level < levelTimer.Length && timer > levelTimer[level])
        {
            level += 1;
            tilesManager.tilesInterval -= level / 10f;
            uiManager.UpdateLevel(level);
        }
    }
}
