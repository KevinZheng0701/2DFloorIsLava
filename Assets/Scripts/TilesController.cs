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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        DrawLine();
    }

    private Vector3 GetWorldPosition(float x, float y)
    {
        return originPosition + new Vector3(x, y) * cellSize;
    }

    public void DrawLine()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x, y + 1), Color.white);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x + 1, y), Color.white);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.white);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.white);
    }
}
