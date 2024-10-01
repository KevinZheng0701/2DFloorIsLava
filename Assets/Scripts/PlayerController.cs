using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public bool isPlayerOne;
    public string horizontalAxis;
    public string verticalAxis;

    // Awake is called during script loading
    void Awake()
    {
        if (GameDataManager.Instance.isSinglePlayer)
        {
            transform.position = Vector3.zero;
            if (!isPlayerOne)
            {
                gameObject.SetActive(false);
            }
        }
    }

    // Fixed update is called every physics update
    void FixedUpdate()
    {
        Vector3 newDirection = Direction();
        transform.Translate(newDirection * speed); // Move the position of the player based on WASD
    }

    // Function to find the direction based on the WASD/joystick/keyboard
    public Vector3 Direction()
    {
        // Unity's default axes providing a value between -1 to 1
        float x = Input.GetAxis(horizontalAxis);
        float y = Input.GetAxis(verticalAxis);
        // Return the direction the player should move based on the horizontal and vertical axes
        return new Vector3(x, y, 0);
    }
}
