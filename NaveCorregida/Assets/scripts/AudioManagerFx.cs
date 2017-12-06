using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManagerFx : MonoBehaviour
{
    public AudioClip PiuLazer;
    public AudioClip Explosion;
    public AudioClip Ganar;
    public AudioSource reproductorAudio;
    public float volumenFx=1;
    public Slider sliderFx;

    void Start()
    {
        reproductorAudio = GetComponent<AudioSource>();
        reproductorAudio.volume = 1;
    }

    void Update()
    {
        if (sliderFx != null)
        {
         volumenFx = sliderFx.value;
         reproductorAudio.volume = volumenFx;
        }

      
    }


    public void activandoAudio(string nombreAudio)
    {
        string nombreCancion = nombreAudio;
        switch (nombreCancion)
        {
            case "Lazer":
                reproductorAudio.PlayOneShot(PiuLazer);


                break;
            case "Explosion":
                reproductorAudio.PlayOneShot(Explosion);

                break;
            case "Ganar":
                reproductorAudio.PlayOneShot(Ganar);

                break;
            default:
                Debug.Log("El nombre es incorrecto");
                break;
        }


       
    }
}
