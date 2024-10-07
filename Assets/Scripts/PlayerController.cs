using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed; // Speed of the player
    public bool isPlayerOne; // Indicate whether this player is the first player
    public string horizontalAxis; // Input manager for horizontal axis
    public string verticalAxis; // Input manager for vertical axis

    // Awake is called during script loading
    void Awake()
    {
        // If the use selects single player mode
        if (GameDataManager.Instance.isSinglePlayer)
        {
            // Move the player to the center
            transform.position = Vector3.zero;
            // Remove the second player
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
