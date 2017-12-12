using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Disparar : MonoBehaviour
{

    public GameObject bala;
    public GameObject nave;
    static public float cooldDownTime = 1;
    public  float currentCooldDownTime = 0;
    public AudioManagerFx reproductorAudio;
    public bool PowerUp;
    float tiempoPowerUp=2;

    public Slider CoolDownTimeSlider;
 
    int counter;

    
    void Start()
    {
     
      
        PowerUp = false;


    }

    void Update()
    {

        CoolDownTimeSlider.minValue = 0;
        CoolDownTimeSlider.maxValue = cooldDownTime;

        if (PowerUp==true)
        {
            tiempoPowerUp -= Time.deltaTime;
            if (tiempoPowerUp <= 0)
            {
                PowerUp = false;
                cooldDownTime = 1;

            }
        }

        if (currentCooldDownTime < 0 && Input.GetKeyUp(KeyCode.Space) && PowerUp==false)
        {
            counter = 0;
            CoolDownTimeSlider.value = currentCooldDownTime;
            DispararEnElButton();
            currentCooldDownTime = cooldDownTime;
           
        }
        else if (currentCooldDownTime < 0 && Input.GetKeyUp(KeyCode.Space) && PowerUp == true)
        {
            CoolDownTimeSlider.value = currentCooldDownTime;
            DispararEnElButton();
            cooldDownTime = 0.01f;
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Mana")
        {
            other.GetComponent<BoxCollider>().enabled = false;
            other.GetComponent<MeshRenderer>().enabled = false;
            PowerUp = true;
        }
    }


    }
