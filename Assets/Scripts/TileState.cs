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
            }
        }
    }

    public void SelectTile(float time)
    {
        SelectingTile();
        isSelected = true;
        timer = time;
    }

    private void SelectingTile()
    {
        for (int i = 0; i < 3; i++)
        {
            StartCoroutine(ChangingColors(.25f));
            colorChangeScript.ChangeColor(Color.white);
        }
    } 
    
    public IEnumerator ChangingColors(float time)
    {
        colorChangeScript.ChangeColor(Color.red);
        yield return new WaitForSeconds(time);
    }

    public bool GetIsSelected()
    {
        return isSelected;
    }
}
