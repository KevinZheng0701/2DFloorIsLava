using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading;

public class TilesSelector : MonoBehaviour
{
    [SerializeField] TilesController tileController;
    private float timer;
    [SerializeField] float tilesInterval;
    [SerializeField] GameManager gameManager;
    private List<GameObject> selectedTiles;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > tilesInterval)
        {
            SelectTiles(gameManager.level);
        }
    }

    private void SelectTiles(int numberOfTiles)
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            GameObject tile = tileController.GetRandomTile();
            while (selectedTiles.Contains(tile))
            {
                tile = tileController.GetRandomTile();
            }
            selectedTiles.Add(tile);
        }
        while (selectedTiles.Count > 0)
        {
            GameObject tile = selectedTiles[0];
            selectedTiles.RemoveAt(0);
            TileState tileStateController = tile.GetComponent<TileState>();
        }
    }
}
