using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesSelector : MonoBehaviour
{
    private float timer;
    public float tilesInterval;
    [SerializeField] TilesController tileController;
    [SerializeField] GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = tilesInterval - 2f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > tilesInterval)
        {
            timer = 0;
            SelectTiles((gameManager.level + 1) * (gameManager.level + 1));
        }
    }

    private void SelectTiles(int numberOfTiles)
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            GameObject tile = tileController.GetRandomTile();
            TileState state = tile.GetComponent<TileState>();
            while (state.GetIsSelected())
            {
                tile = tileController.GetRandomTile();
                state = tile.GetComponent<TileState>();
            }
            state.SelectTile(tilesInterval / 1.5f);
        }
    }
}
