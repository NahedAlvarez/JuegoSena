using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patroll : MonoBehaviour {

    public Transform[] patrolpoint;
    int Point = 0;
    public float velocity;

	void Start ()
    {
        transform.position = patrolpoint[Point].position;
    }
	
	
	void Update ()
    {
		if (transform.position == patrolpoint[Point].position)
        {
            Point++;
             if (Point >= patrolpoint.Length)
             {
                    Point = 0;
             }

        }
        transform.position = Vector3.MoveTowards(transform.position, patrolpoint[Point].position, velocity*Time.deltaTime);



	}
}
