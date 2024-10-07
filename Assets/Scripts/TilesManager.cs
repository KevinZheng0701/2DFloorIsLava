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
            CheckSafety(); // Check the safety of the players
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
        yield return new WaitForSeconds(time * 0.4f);
        isDanger = true;
        yield return new WaitForSeconds(time * 0.6f);
        isDanger = false;
    }

    private void CheckSafety()
    {
        Vector3 playerPos = player1.transform.position;
        Vector3 playerPos2 = player2.transform.position;
        GameObject tile1 = tilesMap.GetTileUnderPlayer(playerPos);
        GameObject tile2 = tilesMap.GetTileUnderPlayer(playerPos2);
        SpriteRenderer spriteRender1 = tile1.GetComponent<SpriteRenderer>();
        SpriteRenderer spriteRender2 = tile2.GetComponent<SpriteRenderer>();
        if (spriteRender1.color == Color.red || spriteRender2.color == Color.red)
        {
            GameDataManager.Instance.timeSurvived = gameManager.timer;
            sceneChanger.MoveToScene(2);
        }
    }
}
