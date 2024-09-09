using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public float spawnInterval = 3f;
    public float spawnTimer = 0f;
    public GameObject objectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            Instantiate(objectPrefab, Vector3.zero, Quaternion.identity);
        }
    }
}
