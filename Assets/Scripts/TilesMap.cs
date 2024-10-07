using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesMap : MonoBehaviour
{
    public int width; // Width of the grid
    public int height; // Height of the grid
    public Vector3 originPosition;  // Starting position of the grid located at bottom left
    public float cellSize; // Size of the grid cells
    public GameObject[,] tiles; // 2D array holding the tiles
    public GameObject tilePrefab; // Tile prefab
    public GameObject tileParent; // Object to hold the tile prefabs

    // Start is called before the first frame update
    void Start()
    {
        tiles = new GameObject[width, height]; // Set the 2D array
        SpawnTiles(); // Spawn the tiles
    }

    // Function to spawn the tiles into the game
    private void SpawnTiles()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Spawn the tile to ensure it fits well in the game scene
                GameObject tile = Instantiate(tilePrefab, GetWorldPosition(x, y) + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
                tile.name = "Tile";
                tile.transform.SetParent(tileParent.transform);
                tiles[x, y] = tile;
            }
        }
    }

    // Function to get the positon of a tile
    private Vector3 GetWorldPosition(float x, float y)
    {
        return originPosition + new Vector3(x, y) * cellSize;
    }

    // Function to get the x and y index based on the world position
    private Vector2Int GetXY(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt((worldPosition.x - originPosition.x) / cellSize);
        int y = Mathf.FloorToInt((worldPosition.y - originPosition.y) / cellSize);
        return new Vector2Int(x, y);
    }

    // Function to get a random tile
    public GameObject GetRandomTile()
    {
        int x = Random.Range(0, width);
        int y = Random.Range(0, height);
        return tiles[x, y];
    }

    // Function to get a tile under a player
    public GameObject GetTileUnderPlayer(Vector3 playerPosition)
    {
        Vector2Int xy = GetXY(playerPosition);
        return tiles[xy.x, xy.y];
    }
}
