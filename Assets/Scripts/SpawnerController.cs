using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    [SerializeField] float spawnInterval;
    [SerializeField] float xBound;
    [SerializeField] float yBound;
    [SerializeField] GameObject objectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawnInterval, 7.5f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void SpawnObject()
    {
        Instantiate(objectPrefab, GetRandomPosition(), Quaternion.identity);
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-xBound, xBound);
        float y = Random.Range(-yBound, yBound);
        return new Vector3(x, y, 0);
    }
}
