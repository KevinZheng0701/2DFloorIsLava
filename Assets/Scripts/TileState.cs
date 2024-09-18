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
        StartCoroutine(SelectingTile(time));
        isSelected = true;
        timer = time;
    }

    private IEnumerator SelectingTile(float time)
    {
        StartCoroutine(ChangingColorsAnimation(time / 10f));
        yield return new WaitForSeconds(time / 5);
        StartCoroutine(ChangingColorsAnimation(time / 10f));
        yield return new WaitForSeconds(time / 5f);
        colorChangeScript.ChangeColor(Color.red);
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
