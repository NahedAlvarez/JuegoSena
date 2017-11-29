using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndPlay : MonoBehaviour
{




	public void Pause ()
    {
    
            if (Time.timeScale == 1.0F)
                Time.timeScale = 0.0F;
            else
                Time.timeScale = 1.0F;
           
    }
}
