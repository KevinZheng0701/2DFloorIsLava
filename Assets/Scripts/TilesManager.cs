using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesManager : MonoBehaviour
{
    private bool isDanger;
    private float timer;
    public float tilesInterval;
    public Transform player1;
    public Transform player2;
    public TilesMap tilesMap;
    public GameManager gameManager;
    public SceneChanger sceneChanger;

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
            CheckSafety();
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
