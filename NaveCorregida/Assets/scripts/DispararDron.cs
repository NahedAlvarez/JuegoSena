using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DispararDron : MonoBehaviour {

    public GameObject bala;
    public float cooldDownTime;
    public float currentCooldDownTime;
    AudioSource reproductorAudio;
    public Transform Target;
    int i;
    /*public AudioClip piu;
    public Slider VolumenFx;
    public Toggle VolumenFxtogle;*/

    void Start()
    {
        reproductorAudio = GetComponent<AudioSource>();
        currentCooldDownTime = cooldDownTime;

    }

    void Update()
    {
       
        if (currentCooldDownTime < 0)
        {
            
                DispararEnElButton();
          
           
            currentCooldDownTime = cooldDownTime;
        }

        currentCooldDownTime -= Time.deltaTime;

        

    }


    public void DispararEnElButton()
    {



        Instantiate(bala, transform.position, bala.transform.rotation);

        
        /*reproductorAudio.PlayOneShot(piu);

        if (VolumenFxtogle.isOn == false)
        {
            reproductorAudio.volume = 0;
        }
        else
        {
            reproductorAudio.volume = 1;
        }
        */


    }
}
