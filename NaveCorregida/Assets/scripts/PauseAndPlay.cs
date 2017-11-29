using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAndPlay : MonoBehaviour
{


    public GameObject Conf;
    public GameObject Score;
    public GameObject StarScreen;
    public void Pause()
    {

        if (Time.timeScale == 1.0F)
        {
            Conf.SetActive(true);
            Time.timeScale = 0.0F;
            Score.SetActive(false);
        }

        else
        {
            Conf.SetActive(false);
            Time.timeScale = 1.0F;
            Score.SetActive(true);
        }
           
    

           
           
    }
}
