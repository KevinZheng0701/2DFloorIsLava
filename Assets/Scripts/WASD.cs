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
        transform.Translate(Direction() * speed); // Move the position of the player based on WASD
    }

    // Function to find the direction based on the WASD/joystick/keyboard
    public Vector3 Direction()
    {
        // Unity's default axes providing a value between -1 to 1
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        // Return the direction the player should move based on the horizontal and vertical axes
        return new Vector3(x, y, 0);
    }
}
