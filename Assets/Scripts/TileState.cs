using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileState : MonoBehaviour
{
    private bool isSelected; // Status to indicate whether the current tile is being selected
    private float timer; // Timer for the duration of how long to be selected
    public ColorChange colorChangeScript; // Reference the color change script

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            // Decrease time if timer is still positive
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else // Duration is over so change the color of the tile back to white and deselect the tile
            {
                isSelected = false;
                colorChangeScript.ChangeColor(Color.white);
            }
        }
    }

    // Function to select a tile with a certain time
    public void SelectTile(float time)
    {
        StartCoroutine(SelectingTile(time / 10f)); // Start the animation for selecting the tile
        // Update the duration and set the tile to be selected
        isSelected = true;
        timer = time;
    }

    // Function for the selecting tile animation
    private IEnumerator SelectingTile(float delay)
    {
        StartCoroutine(ChangingColorsAnimation(delay));
        yield return new WaitForSeconds(delay * 2f);
        StartCoroutine(ChangingColorsAnimation(delay));
        yield return new WaitForSeconds(delay * 2f);
        colorChangeScript.ChangeColor(Color.red);
    }

    // Function to change the color to red and back to white with a delay
    public IEnumerator ChangingColorsAnimation(float time)
    {
        colorChangeScript.ChangeColor(Color.red);
        yield return new WaitForSeconds(time);
        colorChangeScript.ChangeColor(Color.white);
    }

    // Method to get the selected state of a tile
    public bool GetIsSelected()
    {
        return isSelected;
    }
}
