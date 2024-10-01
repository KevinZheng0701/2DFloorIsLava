using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMode : MonoBehaviour
{
    public Button singlePlayerButton;
    public Button twoPlayerButton;

    // Start is called before the first frame update
    void Start()
    {
        GameDataManager gameDataManager = GameDataManager.Instance;
        singlePlayerButton.onClick.AddListener(() => gameDataManager.SetToSinglePlayer());
        twoPlayerButton.onClick.AddListener(() => gameDataManager.SetToTwoPlayers());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
