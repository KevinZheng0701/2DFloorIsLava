using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesSelector : MonoBehaviour
{
    private float timer;
    [SerializeField] TilesController tileController;
    [SerializeField] float tilesInterval;
    [SerializeField] GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > tilesInterval)
        {
            timer = 0;
            SelectTiles((gameManager.level + 1) * 3);
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
            state.SelectTile(timer);
        }
    }
}
