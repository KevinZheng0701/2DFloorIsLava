using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMode : MonoBehaviour
{
    public Button singlePlayerButton; // Reference to the single mode button
    public Button twoPlayerButton; // Reference to the two players mode button

    // Start is called before the first frame update
    void Start()
    {
        GameDataManager gameDataManager = GameDataManager.Instance; // Get the game data manager
        // Add the function to the buttons to set the mode because going back to the main scene will destroy the new game data manager
        singlePlayerButton.onClick.AddListener(() => gameDataManager.SetToSinglePlayer());
        twoPlayerButton.onClick.AddListener(() => gameDataManager.SetToTwoPlayers());
    }
}
