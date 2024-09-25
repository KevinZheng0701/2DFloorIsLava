using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canMove; 
    public float speed;
    private bool isSingle;
    public bool isPlayerOne;
    [SerializeField] string horizontalAxis;
    [SerializeField] string verticalAxis;

    // Start is called before the first frame update
    void Start()
    {
        isSingle = GameDataManager.Instance.isSinglePlayer;
        if (isSingle && isPlayerOne)
        {
            canMove = true;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Fixed update is called 50 times per second
    void FixedUpdate()
    {
        if (canMove)
        {
            Vector3 newDirection = Direction();
            transform.Translate(newDirection * speed); // Move the position of the player based on WASD
        }
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
