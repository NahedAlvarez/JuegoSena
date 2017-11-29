using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocidadBala : MonoBehaviour {

    public float velocidad=100;

	

	void Update ()
    {
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime, Space.World);
	}
}
