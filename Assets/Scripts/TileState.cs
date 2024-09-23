using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileState : MonoBehaviour
{
    private bool isSelected;
    private float timer;
    [SerializeField] ColorChange colorChangeScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelected)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            } else {
                isSelected = false;
                colorChangeScript.ChangeColor(Color.white);
            }
        }
    }

    public void SelectTile(float time)
    {
        StartCoroutine(SelectingTile(time / 10f));
        isSelected = true;
        timer = time;
    }

    private IEnumerator SelectingTile(float delay)
    {
        StartCoroutine(ChangingColorsAnimation(delay));
        yield return new WaitForSeconds(delay * 2f);
        StartCoroutine(ChangingColorsAnimation(delay));
        yield return new WaitForSeconds(delay * 2f);
        colorChangeScript.ChangeColor(Color.red);
        Debug.Log("Time for tile to turn red: " + delay * 6f);
    } 
    
    public IEnumerator ChangingColorsAnimation(float time)
    {
        colorChangeScript.ChangeColor(Color.red);
        yield return new WaitForSeconds(time);
        colorChangeScript.ChangeColor(Color.white);
    }

    public bool GetIsSelected()
    {
        return isSelected;
    }
}
