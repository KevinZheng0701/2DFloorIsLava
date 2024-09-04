using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float timer = 0f;
    public float fixedTimer = 0f;
    public float spawnInterval = 3f;
    public float spawnTimer = 0f;
    public GameObject enemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity);
        }
    }

    void FixedUpdate()
    {
        fixedTimer += Time.fixedDeltaTime;
    }
}
