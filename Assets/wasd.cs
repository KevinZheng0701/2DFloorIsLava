using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Fixed update is called 50 times per second
    void FixedUpdate()
    {
        transform.Translate(Direction());
    }

    public Vector3 Direction()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 myDirection = new Vector3(x, y, 0);
        return myDirection * speed;
    }
}
