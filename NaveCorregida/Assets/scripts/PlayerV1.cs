using UnityEngine;
using System.Collections;


/// <summary>
/// only horizontal movement
/// </summary>
public class PlayerV1 : MonoBehaviour
{
    //Variable publica que nos da la velocidad de giro de nuestra nave
    public float turnSpeed = 1;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Guardamos en nuestra variable si nos movemos hacia la izq o drch (-1/1)
        var horiz = Input.GetAxis("Horizontal");
        //Modificamos el valor del transform (la posicion) por la velocidad inicial + eje Horiozontal * velocidad de giro * tiempo que tardamos en completar un frame
        transform.position = transform.position + transform.right * turnSpeed * horiz * Time.deltaTime;
        
    }
}
