using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASD : MonoBehaviour
{
    public UIManager uiManager;
    public int score;
    public float horSpeed; // Speed of the player in the horizontal direction
    public float vertSpeed; // Speed of the player in the vertical direction

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
        Vector3 newDirection = Direction();
        // Add more control to the speed of the player
        newDirection.x *= horSpeed;
        newDirection.y *= vertSpeed;
        transform.Translate(newDirection); // Move the position of the player based on WASD
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Collectible"))
        {
            score++;
            Destroy(collider.gameObject);
            uiManager.UpdateScore(score);
        }
    }
}
