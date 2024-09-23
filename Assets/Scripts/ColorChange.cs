using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public SpriteRenderer sprite;

    // Function to visually change the color of the object
    public void ChangeColor(Color newColor)
    {
        sprite.color = newColor;
    }
}
