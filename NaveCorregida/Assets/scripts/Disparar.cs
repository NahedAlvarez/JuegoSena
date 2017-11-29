using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Disparar : MonoBehaviour
{

    public GameObject bala;
    public float cooldDownTime = 0.2f;
    private float currentCooldDownTime = 0;
    AudioSource reproductorAudio;
    public AudioClip piu;
    public Slider VolumenFx;
    public Toggle VolumenFxtogle;
    void Start()
    {
        reproductorAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (currentCooldDownTime < 0)
        {
            DispararEnElButton();
        }
        currentCooldDownTime -= Time.deltaTime;

    }


    void DispararEnElButton()
    {
      
         
            currentCooldDownTime = cooldDownTime;
            Instantiate(bala, transform.position, bala.transform.rotation);    
            reproductorAudio.PlayOneShot(piu);
            reproductorAudio.volume = VolumenFx.value;
            if (VolumenFxtogle.isOn == false)
            {
            reproductorAudio.volume = 0;
            }
            else
            {
            reproductorAudio.volume = 1;
            }



    }
}
