using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerFx : MonoBehaviour
{
    public AudioClip PiuLazer;
    public AudioClip Explosion;
    public AudioClip Ganar;
    public AudioSource reproductorAudio;
	
	void Start ()
    {
        reproductorAudio = GetComponent<AudioSource>();
    }
	

	void Update ()
    {
		
	}
    public void activandoAudio(string nombreAudio)
    {
        string nombreCancion = nombreAudio;
        switch (nombreCancion)
        {
            case "saludActiva":
                reproductorAudio.PlayOneShot(PiuLazer);
                Debug.Log("Activado el audio piuLazer");
                break;
            case "venenoActivo":
                reproductorAudio.PlayOneShot(Explosion);
                Debug.Log("Activado el audio Explosion");
                break;
            case "Ganar":
                reproductorAudio.PlayOneShot(Ganar);
                Debug.Log("Activado el audio Ganar");
                break;
            default:
                Debug.Log("El nombre es incorrecto");
                break;
        }
    }
}
