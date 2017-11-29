using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnColorScrip : MonoBehaviour
{
    Material material;
    private void Start()
    {
        material = GetComponent<Renderer>().material;
    }



  
    public void TurnColor()
    {
        Color col = new Color(Random.value, Random.value, Random.value);
        material.color = col;
    }
    


}
