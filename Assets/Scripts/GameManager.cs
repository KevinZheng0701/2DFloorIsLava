using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int level;
    public float timer;
    public TilesManager tilesManager;
    public UIManager uiManager;
    public int[] levelTimer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        uiManager.UpdateTimer(timer);
        if (level < levelTimer.Length && timer > levelTimer[level])
        {
            level += 1;
            tilesManager.tilesInterval -= level / 10f;
            uiManager.UpdateLevel(level);
        }
    }
}
