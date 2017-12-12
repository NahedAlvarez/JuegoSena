using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroll : MonoBehaviour {

    public Transform[] patrolpoint;
    int Point = 0;
    public float velocity;

	void Start ()
    {
        //que se vaya para el punto 1 al principio
        transform.position = patrolpoint[Point].position;
    }
	
	
	void Update ()
    {
        //se utiliza es te codigo para que vayan pasando por todos los patroll point los drones 
		if (transform.position == patrolpoint[Point].position)
        {
            //se aumenta el punto de patroll
            Point++;
            //Si pasa del maximo punto que se devuelva al punto 
            if (Point >= patrolpoint.Length)
             {
                 
                    Point = 0;
             }

        }
        //que se mueva por todos los pint 
        transform.position = Vector3.MoveTowards(transform.position, patrolpoint[Point].position, velocity*Time.deltaTime);



	}
}
