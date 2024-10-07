using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    private bool isDanger; // Boolean to determine whether the player is in danger zone
    private float timer; // Timer to select tiles
    public float tilesInterval; // The interval for selecting tiles
    public Transform player1; // Position of player 1
    public Transform player2; // Position of player 2
    public TilesMap tilesMap; // Reference the tiles
    public GameManager gameManager; // Reference the game manager
    public SceneChanger sceneChanger; // Reference the scene changer

    // Start is called before the first frame update
    void Start()
    {
        timer = tilesInterval - 2f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime; // Update time
        // Check if right now is dangerous
        if (isDanger)
        {
            bool isSafe = CheckSafety(player1); // Check the safety of the first player
            // If there is a second player then check if it is safe
            if (!GameDataManager.Instance.isSinglePlayer)
            {
                isSafe = isSafe && CheckSafety(player2); // Use and statement to get the safeness of both players
            }
            // If it is not safe then go to end scene and update the time survived
            if (!isSafe)
            {
                GameDataManager.Instance.timeSurvived = gameManager.timer;
                sceneChanger.MoveToScene(2);
            }
        }
        // Timer reached the time to select new tiles
        if (timer > tilesInterval)
        {
            timer = 0; // Reset the timer
            SelectTiles((gameManager.level + 1) * (gameManager.level + 1)); // Select new tiles with difficulty adjusted
        }
    }

    // Function to select a certain number of tiles
    private void SelectTiles(int numberOfTiles)
    {
        float selectedTime = tilesInterval / 1.5f; // The time for the tile to be selected
        for (int i = 0; i < numberOfTiles; i++)
        {
            GameObject tile = tilesMap.GetRandomTile(); // Get a random tile
            TileState state = tile.GetComponent<TileState>(); // Get the tile state
            // Get new tile if the previously selected tile is already selected
            while (state.GetIsSelected())
            {
                tile = tilesMap.GetRandomTile();
                state = tile.GetComponent<TileState>();
            }
            state.SelectTile(selectedTime); // Update the state of the tile
        }
        StartCoroutine(CheckPlayer(selectedTime)); // Start the coroutine to check the player after the selected time
    }

    // Function to check if player is in danger mode
    public IEnumerator CheckPlayer(float time)
    {
        // After all tiles are red set danger to be true
        yield return new WaitForSeconds(time * 0.4f);
        isDanger = true;
        // After tiles turn back into white set danger to be false
        yield return new WaitForSeconds(time * 0.6f);
        isDanger = false;
    }

    // Function to check whether the player is safe
    private bool CheckSafety(Transform player)
    {
        // Get the tiles under the player
        Vector3 playerPos = player.transform.position;
        GameObject tile = tilesMap.GetTileUnderPlayer(playerPos);
        SpriteRenderer spriteRender = tile.GetComponent<SpriteRenderer>();
        // If the tile is red then it is not safe
        if (spriteRender.color == Color.red)
        {
            return false;
        }
        return true;
    }
}
