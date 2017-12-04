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
    public AudioManagerFx reproductorAudio;

    public Slider CoolDownTimeSlider;
 
    int counter;

    Player DispararMasRapido;
    void Start()
    {
     
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
            reproductorAudio.activandoAudio("Lazer");
        
           
           



    }
}
