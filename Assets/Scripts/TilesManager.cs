using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    private bool isDanger;
    private float timer;
    public float tilesInterval;
    [SerializeField] Transform player;
    [SerializeField] TilesMap tilesMap;
    [SerializeField] GameManager gameManager;
    [SerializeField] SceneChanger sceneChanger;
    
    // Start is called before the first frame update
    void Start()
    {
        timer = tilesInterval - 2f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (isDanger)
        {
            Vector3 playerPos = player.transform.position;
            GameObject tile = tilesMap.GetTileUnderPlayer(playerPos);
            SpriteRenderer spriteRender = tile.GetComponent<SpriteRenderer>();
            if (spriteRender.color == Color.red)
            {
                Debug.Log("red!");
                //sceneChanger.MoveToScene(2);
            }
        }
        if (timer > tilesInterval)
        {
            timer = 0;
            SelectTiles((gameManager.level + 1) * (gameManager.level + 1));
        }
    }

    private void SelectTiles(int numberOfTiles)
    {
        float selectedTime = tilesInterval / 1.5f;
        for (int i = 0; i < numberOfTiles; i++)
        {
            GameObject tile = tilesMap.GetRandomTile();
            TileState state = tile.GetComponent<TileState>();
            while (state.GetIsSelected())
            {
                tile = tilesMap.GetRandomTile();
                state = tile.GetComponent<TileState>();
            }
            state.SelectTile(selectedTime);
        }
        StartCoroutine(CheckPlayer(selectedTime));
    }

    public IEnumerator CheckPlayer(float time)
    {
        yield return new WaitForSeconds(time * 0.4f);
        Debug.Log("Checking now: " + time * 0.4f);
        isDanger = true;
        yield return new WaitForSeconds(time * 0.6f);
        isDanger = false;
    }
}
