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



    void Start()
    {
       
        currentCooldDownTime = cooldDownTime;

    }

    void Update()
    {
       
        if (currentCooldDownTime < 0)
        {
            //Se instancia el projectile
            Instantiate(bala, transform.position, bala.transform.rotation);

            //current cooldown se vuelve igual a 5 que es lo que tiene el cooldown 
            currentCooldDownTime = cooldDownTime;
        }
        //se le resta tiempo al current cooldown 
        currentCooldDownTime -= Time.deltaTime;

        

    }


  
}
