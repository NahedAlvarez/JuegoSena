using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Disparar : MonoBehaviour
{

    public GameObject bala;
    public GameObject nave;
    static public float cooldDownTime = 5;
    public  float currentCooldDownTime = 0;
    AudioSource reproductorAudio;
    public AudioClip piu;
    public Slider VolumenFx;
    public Toggle VolumenFxtogle;
    public Slider CoolDownTimeSlider;
    float Disparar2veces;
    int counter;

    Player DispararMasRapido;
    void Start()
    {
        reproductorAudio = GetComponent<AudioSource>();
        DispararMasRapido = GetComponent<Player>();


    }

    void Update()
    {
   
       

        if (currentCooldDownTime < 0 && Input.GetKeyUp(KeyCode.Space))
        {
            CoolDownTimeSlider.value = currentCooldDownTime;
            DispararEnElButton();
            currentCooldDownTime = cooldDownTime;
           
        }
       
        currentCooldDownTime -= Time.deltaTime;
        CoolDownTimeSlider.value = currentCooldDownTime;


    }


    public void DispararEnElButton()
    {
      
         
           
            Instantiate(bala, transform.position, bala.transform.rotation);    
            reproductorAudio.PlayOneShot(piu);
        
           
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
