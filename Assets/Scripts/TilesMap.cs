using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesMap : MonoBehaviour
{
    public int width;
    public int height;
    public Vector3 originPosition;
    public float cellSize;
    public GameObject[,] tiles;
    [SerializeField] GameObject tilePrefab;
    [SerializeField] GameObject tileParent;

    // Start is called before the first frame update
    void Start()
    {
       tiles = new GameObject[width, height];
       SpawnTiles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnTiles()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject tile = Instantiate(tilePrefab, GetWorldPosition(x, y) + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
                tile.name = "Tile";
                tile.transform.SetParent(tileParent.transform);
                tiles[x, y] = tile;
            }
        }
    }

    private Vector3 GetWorldPosition(float x, float y)
    {
        return originPosition + new Vector3(x, y) * cellSize;
    }

    private Vector2Int GetXY(Vector3 worldPosition)
    {
        int x = Mathf.FloorToInt((worldPosition.x - originPosition.x) / cellSize);
        int y = Mathf.FloorToInt((worldPosition.y - originPosition.y) / cellSize);
        return new Vector2Int(x, y);
    }

    public GameObject GetRandomTile()
    {
        int x = Random.Range(0, width);
        int y = Random.Range(0, height);
        return tiles[x, y];
    }

    public GameObject GetTileUnderPlayer(Vector3 playerPosition)
    {
        Vector2Int xy = GetXY(playerPosition);
        return tiles[xy.x, xy.y];
    }
}
