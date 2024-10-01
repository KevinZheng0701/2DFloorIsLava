using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateTimer : MonoBehaviour
{
    public UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        GameDataManager gameDataManager = GameObject.FindGameObjectWithTag("Data").GetComponent<GameDataManager>();
        uiManager.UpdateFinalTimer(gameDataManager.timeSurvived);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
