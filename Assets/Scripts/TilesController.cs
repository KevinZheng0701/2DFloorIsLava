using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesController : MonoBehaviour
{
    public int width;
    public int height;
    public Vector3 originPosition;
    public float cellSize;
    public GameObject tilePrefab;
    public GameObject tileParent;
    public GameObject[,] tiles;

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

    public GameObject GetRandomTile()
    {
        int x = Random.Range(0, width);
        int y = Random.Range(0, height);
        return tiles[x, y];
    }
}
